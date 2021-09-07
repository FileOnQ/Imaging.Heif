using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	partial class LibHeif
	{
		private unsafe class x86
		{
			const string DllName = "heif.dll";

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern Context* heif_context_alloc();

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void heif_context_free(Context* context);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern Error heif_context_read_from_file(Context* context, string filename, IntPtr options);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern int heif_image_handle_get_number_of_thumbnails(ImageHandle* handle);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern int heif_image_handle_get_list_of_thumbnail_IDs(ImageHandle* handle, uint* itemIds, int count);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern Error heif_image_handle_get_thumbnail(ImageHandle* handle, uint itemId, ImageHandle** output);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern Error heif_context_get_primary_image_handle(Context* context, ImageHandle** output);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr heif_decoding_options_alloc();

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern int heif_image_handle_has_alpha_channel(ImageHandle* handle);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern int heif_image_handle_get_luma_bits_per_pixel(ImageHandle* handle);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern Error heif_decode_image(ImageHandle* inputImage, Image** outputImage, ColorSpace colorSpace, Chroma chroma, IntPtr decodingOptions);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void heif_decoding_options_free(IntPtr decodingOptions);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void heif_image_handle_release(ImageHandle* handle);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void heif_image_release(Image* image);
		}
	}
}
