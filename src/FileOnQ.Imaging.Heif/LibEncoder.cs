using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	unsafe class LibEncoder
	{
		const string DllName = "FileOnQ.Imaging.Heif.Encoders.dll";

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr encoder_jpeg_init(int quality);

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern LibHeifContext.ColorSpace encoder_colorspace(IntPtr encoder, bool hasAlpha);

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern LibHeifContext.Chroma encoder_chroma(IntPtr encoder, bool hasAlpha, int bitDepth);

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern bool encode(IntPtr encoder, LibHeifContext.ImageHandle* handle, LibHeifContext.Image* image, string filename);

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr encoder_free(IntPtr encoder);

		[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void encoder_update_decoding_options(IntPtr encoder, LibHeifContext.ImageHandle* handle, IntPtr decodingOptions);
	}
}
