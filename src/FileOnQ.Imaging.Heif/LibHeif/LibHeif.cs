using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	public static unsafe partial class LibHeif
	{
		internal static Context* ContextAllocate()
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_context_alloc();
				case Architecture.X86:
					return x86.heif_context_alloc();
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void FreeContext(Context* context)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					x64.heif_context_free(context);
					break;
				case Architecture.X86:
					x86.heif_context_free(context);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static Error ReadFromFile(Context* context, string filename, IntPtr options)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_context_read_from_file(context, filename, options);
				case Architecture.X86:
					return x86.heif_context_read_from_file(context, filename, options);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static int GetNumberOfThumbnails(ImageHandle* handle)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_image_handle_get_number_of_thumbnails(handle);
				case Architecture.X86:
					return x86.heif_image_handle_get_number_of_thumbnails(handle);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static int GetListOfThumbnailIds(ImageHandle* handle, uint* itemIds, int count)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_image_handle_get_list_of_thumbnail_IDs(handle, itemIds, count);
				case Architecture.X86:
					return x86.heif_image_handle_get_list_of_thumbnail_IDs(handle, itemIds, count);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static Error GetThumbnail(ImageHandle* handle, uint itemId, ImageHandle** output)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_image_handle_get_thumbnail(handle, itemId, output);
				case Architecture.X86:
					return x86.heif_image_handle_get_thumbnail(handle, itemId, output);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}


		internal static Error GetPrimaryImageHandle(Context* context, ImageHandle** output)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_context_get_primary_image_handle(context, output);
				case Architecture.X86:
					return x86.heif_context_get_primary_image_handle(context, output);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static IntPtr DecodingOptionsAllocate()
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_decoding_options_alloc();
				case Architecture.X86:
					return x86.heif_decoding_options_alloc();
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static bool HasAlphaChannel(ImageHandle* handle)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_image_handle_has_alpha_channel(handle) == 1;
				case Architecture.X86:
					return x86.heif_image_handle_has_alpha_channel(handle) == 1;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static int GetLumaBitsPerPixel(ImageHandle* handle)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_image_handle_get_luma_bits_per_pixel(handle);
				case Architecture.X86:
					return x86.heif_image_handle_get_luma_bits_per_pixel(handle);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static Error DecodeImage(ImageHandle* inputImage, Image** outputImage, ColorSpace colorSpace, Chroma chroma, IntPtr decodingOptions)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.heif_decode_image(inputImage, outputImage, colorSpace, chroma, decodingOptions);
				case Architecture.X86:
					return x86.heif_decode_image(inputImage, outputImage, colorSpace, chroma, decodingOptions);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void FreeDecodingOptions(IntPtr decodingOptions)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					x64.heif_decoding_options_free(decodingOptions);
					break;
				case Architecture.X86:
					x86.heif_decoding_options_free(decodingOptions);
					break;	
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}


		internal static void ReleaseImageHandle(ImageHandle* handle)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					x64.heif_image_handle_release(handle);
					break;
				case Architecture.X86:
					x86.heif_image_handle_release(handle);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void ReleaseImage(Image* image)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					x64.heif_image_release(image);
					break;
				case Architecture.X86:
					x86.heif_image_release(image);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}
	}
}
