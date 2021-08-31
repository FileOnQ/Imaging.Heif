using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	public unsafe class HeifImage : IHeifImage
	{
		LibHeif.Context* heifContext;
		public HeifImage(string file)
		{
			heifContext = LibHeif.ContextAllocate();
			var error = LibHeif.ReadFromFile(heifContext, file, IntPtr.Zero);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new Exception(Marshal.PtrToStringAnsi(error.Message));
		}

		public IImage Thumbnail()
		{
			LibHeif.ImageHandle* primaryImageHandle;
			var error = LibHeif.GetPrimaryImageHandle(heifContext, &primaryImageHandle);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new Exception(Marshal.PtrToStringAnsi(error.Message));

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
						throw new Exception(Marshal.PtrToStringAnsi(thumbError.Message));

					return new Image(thumbHandle);
				}
				else
					throw new Exception("No thumbnail found");
			}
			finally
			{
				// REVIEW - will this hide exceptions being thrown above?
				// the goal is to make sure that we always release memory
				LibHeif.ReleaseImageHandle(primaryImageHandle);
			}
		}

		public IImage PrimaryImage()
		{
			LibHeif.ImageHandle* primaryImageHandle;
			var error = LibHeif.GetPrimaryImageHandle(heifContext, &primaryImageHandle);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new Exception(Marshal.PtrToStringAnsi(error.Message));

			return new Image(primaryImageHandle);
		}

		~HeifImage() => Dispose(false);

		bool isDisposed;
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
