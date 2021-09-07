using System;
using System.IO;

namespace FileOnQ.Imaging.Heif
{
	internal unsafe class Image : IImage
	{
		LibHeif.ImageHandle* handle;
		IntPtr encoder;
		IntPtr decodingOptions;
		internal Image(LibHeif.ImageHandle* handle)
		{
			if ((IntPtr)handle == IntPtr.Zero)
				throw new NullReferenceException("Unable to use null image handle");

			this.handle = handle;
		}

		public void Write(string filename, int quality = 90)
		{
			CreateEncoder(quality);
			CreateDecodingOptions();
			
			var bitDepth = LibHeif.GetLumaBitsPerPixel(handle);
			if (bitDepth < 0)
			{
				throw new HeifException(new HeifException.Error
				{
					Code = LibHeif.ErrorCode.UnsupportedFileType,
					SubCode = LibHeif.SubErrorCode.heif_suberror_Unsupported_bit_depth,
					Message = "Image has undefined bit-depth, unable to save" 
				});
			}

			var hasAlpha = LibHeif.HasAlphaChannel(handle);
			LibHeif.Image* outputImage;
			var decodeError = LibHeif.DecodeImage(
				handle,
				&outputImage,
				LibEncoder.GetColorSpace(encoder, hasAlpha),
				LibEncoder.GetChroma(encoder, hasAlpha, bitDepth),
				decodingOptions);


			if (decodeError.Code != LibHeif.ErrorCode.Ok)
				throw new HeifException(decodeError);

			if ((IntPtr)outputImage != IntPtr.Zero)
			{
				byte* buffer = (byte*)IntPtr.Zero;
				ulong size;

				try
				{
					bool saved = LibEncoder.Encode(encoder, handle, outputImage, &buffer, &size);
					if (saved)
					{
						var span = new ReadOnlySpan<byte>((void*)buffer, (int)size);
						using (var fileStream = File.OpenWrite(filename))
						{
#if NET5_0_OR_GREATER
							fileStream.Write(span);
#elif NET48_OR_GREATER
							fileStream.Write(span.ToArray(), 0, span.Length);
#endif
						}
					}
					else
					{
						throw new HeifException(new HeifException.Error
						{
							Code = LibHeif.ErrorCode.NoThumbnail,
							SubCode = LibHeif.SubErrorCode.heif_suberror_Unspecified,
							Message = "Unable to save image"
						});
					}
				}
				catch (Exception ex)
				{
					throw new HeifException(ex, new HeifException.Error
					{
						Code = LibHeif.ErrorCode.Failure,
						SubCode = LibHeif.SubErrorCode.heif_suberror_Unspecified,
						Message = "See native exception details"
					});
				}
				finally
				{
					if ((IntPtr)buffer != IntPtr.Zero)
					{
						LibEncoder.Free((IntPtr)buffer);
					}

					if ((IntPtr)outputImage != IntPtr.Zero)
					{
						LibHeif.ReleaseImage(outputImage);
					}
				}
			}
		}

		void CreateEncoder(int quality)
		{
			if (encoder == IntPtr.Zero)
				encoder = LibEncoder.InitJpegEncoder(quality);
			else
			{
				LibEncoder.Free(encoder);
				encoder = LibEncoder.InitJpegEncoder(quality);
			}
		}
		void CreateDecodingOptions()
		{
			if (decodingOptions == IntPtr.Zero)
				decodingOptions = LibHeif.DecodingOptionsAllocate();
			else
			{
				LibHeif.FreeDecodingOptions(decodingOptions);
				decodingOptions = LibHeif.DecodingOptionsAllocate();
			}

			LibEncoder.UpdateDecodingOptions(encoder, handle, decodingOptions);
		}

		~Image() => Dispose(false);

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

			if (decodingOptions != IntPtr.Zero)
			{
				LibHeif.FreeDecodingOptions(decodingOptions);
				decodingOptions = IntPtr.Zero;
			}

			if ((IntPtr)handle != IntPtr.Zero)
			{
				LibHeif.ReleaseImageHandle(handle);
				handle = null;
			}

			if (encoder != IntPtr.Zero)
			{
				LibEncoder.Free(encoder);
				encoder = IntPtr.Zero;
			}
			

			isDisposed = true;
		}
	}
}
