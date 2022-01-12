using System;

namespace FileOnQ.Imaging.Heif
{
	/// <inheritdoc cref="IHeifImage"/>
	public unsafe class HeifImage : IHeifImage
	{
	
		LibHeif.Context* heifContext;
		/// <summary>
		/// Instantiates the default instance of
		/// <see cref="HeifImage"/>
		/// with an image from storage using the file path.
		/// </summary>
		/// <param name="file">
		/// The storage location where to find the image to open.
		/// </param>
		public HeifImage(string file)
		{
			heifContext = LibHeif.ContextAllocate();
			var error = LibHeif.ReadFromFile(heifContext, file, IntPtr.Zero);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new HeifException(error);
		}

		/// <inheritdoc cref="IHeifImage"/>
		public IImage Thumbnail()
		{
			LibHeif.ImageHandle* primaryImageHandle;
			var error = LibHeif.GetPrimaryImageHandle(heifContext, &primaryImageHandle);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new HeifException(error);

			try
			{
				var numberOfThumbnails = LibHeif.GetNumberOfThumbnails(primaryImageHandle);
				if (numberOfThumbnails > 0)
				{
					var itemIds = new uint[numberOfThumbnails];
					fixed (uint* ptr = itemIds)
					{
						LibHeif.GetListOfThumbnailIds(primaryImageHandle, ptr, numberOfThumbnails);
					}

					LibHeif.ImageHandle* thumbHandle;
					var thumbError = LibHeif.GetThumbnail(primaryImageHandle, itemIds[0], &thumbHandle);
					if (thumbError.Code != LibHeif.ErrorCode.Ok)
						throw new HeifException(error);

					return new Image(thumbHandle);
				}
				else
				{
					throw new HeifException(new HeifException.Error
					{
						Code = LibHeif.ErrorCode.NoThumbnail,
						SubCode = LibHeif.SubErrorCode.heif_suberror_Unspecified,
						Message = "No thumbnail found in file"
					});
				}
			}
			finally
			{
				LibHeif.ReleaseImageHandle(primaryImageHandle);
			}
		}
		/// <inheritdoc cref="IHeifImage"/>
		public IImage PrimaryImage()
		{
			LibHeif.ImageHandle* primaryImageHandle;
			var error = LibHeif.GetPrimaryImageHandle(heifContext, &primaryImageHandle);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new HeifException(error);

			return new Image(primaryImageHandle);
		}

		~HeifImage() => Dispose(false);

		bool isDisposed;
		/// <inheritdoc cref="IDisposable"/>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (isDisposed)
				return;

			if (disposing)
			{
				// free managed resources
			}

			if ((IntPtr)heifContext != IntPtr.Zero)
			{
				LibHeif.FreeContext(heifContext);
				heifContext = null;
			}

			isDisposed = true;
		}
	}
}
