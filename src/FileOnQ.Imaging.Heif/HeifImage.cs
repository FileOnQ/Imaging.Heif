using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	public unsafe class HeifImage : IDisposable
    {
		LibHeif.Context* heifContext;
		public HeifImage(string file)
		{
			heifContext = LibHeif.ContextAllocate();
			var error = LibHeif.ReadFromFile(heifContext, file, IntPtr.Zero);
			if (error.Code != LibHeif.ErrorCode.Ok)
				throw new Exception(Marshal.PtrToStringAnsi(error.Message));

			LibHeif.ImageHandle* imageHandle;
			var imageError = LibHeif.GetPrimaryImageHandle(heifContext, &imageHandle);

			var numberOfThumbnails = LibHeif.GetNumberOfThumbnails(imageHandle);
			if (numberOfThumbnails > 0)
			{
				var itemIds = new uint[numberOfThumbnails];
				fixed (uint* ptr = itemIds)
				{
					LibHeif.GetListOfThumbnailIds(imageHandle, ptr, numberOfThumbnails);
				}

				// no idea why this is failing
				LibHeif.ImageHandle* thumbHandle;
				var thumbError = LibHeif.GetThumbnail(imageHandle, itemIds[0], &thumbHandle);
				if (thumbError.Code != LibHeif.ErrorCode.Ok)
					throw new Exception(Marshal.PtrToStringAnsi(thumbError.Message));

				Encode(thumbHandle);
			}
			else
			{
				Encode(imageHandle);
			}

			void Encode(LibHeif.ImageHandle* handle)
			{
				var hasAlpha = LibHeif.HasAlphaChannel(handle);
				var encoder = LibEncoder.InitJpegEncoder(90);
				var options = LibHeif.DecodingOptionsAllocate();
				LibEncoder.UpdateDecodingOptions(encoder, handle, options);

				var bitDepth = LibHeif.GetLumaBitsPerPixel(handle);
				if (bitDepth < 0)
				{
					LibHeif.FreeDecodingOptinos(options);
					LibHeif.ReleaseImageHandle(handle);
					throw new Exception("Input image has undefined bit-dept");
				}

				LibHeif.Image* outputImage;
				var decodeError = LibHeif.DecodeImage(
					handle,
					&outputImage,
					LibEncoder.GetColorSpace(encoder, hasAlpha),
					LibEncoder.GetChroma(encoder, hasAlpha, bitDepth),
					options);

				LibHeif.FreeDecodingOptinos(options);

				if (decodeError.Code != LibHeif.ErrorCode.Ok)
				{
					LibHeif.ReleaseImageHandle(handle);
					throw new Exception(Marshal.PtrToStringAnsi(decodeError.Message));
				}

				if ((IntPtr)outputImage != IntPtr.Zero)
				{
					bool saved = LibEncoder.Encode(encoder, handle, outputImage, "output.jpeg");
					if (!saved)
						throw new Exception("Unable to save");
				}

				LibEncoder.Free(encoder);
			}
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

			if (heifContext != null)
			{
				LibHeif.FreeContext(heifContext);
				heifContext = null;
			}

			isDisposed = true;
		}
	}
}
