using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	partial class LibEncoder
	{
		private unsafe class x64
		{
			const string DllName = "FileOnQ.Imaging.Heif.Encoders.dll";

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr encoder_jpeg_init(int quality);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern LibHeif.ColorSpace encoder_colorspace(IntPtr encoder, bool hasAlpha);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern LibHeif.Chroma encoder_chroma(IntPtr encoder, bool hasAlpha, int bitDepth);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern bool encode(IntPtr encoder, LibHeif.ImageHandle* handle, LibHeif.Image* image, byte** buffer, ulong* buffer_size);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void free_pointer(IntPtr pointer);

			[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			internal static extern void encoder_update_decoding_options(IntPtr encoder, LibHeif.ImageHandle* handle, IntPtr decodingOptions);
		}
	}
}
