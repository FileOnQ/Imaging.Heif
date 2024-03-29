﻿using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	unsafe partial class LibEncoder
	{
		internal static IntPtr InitJpegEncoder(int quality)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					return Native.encoder_jpeg_init(quality);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static LibHeif.ColorSpace GetColorSpace(IntPtr encoder, bool hasAlpha)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					return Native.encoder_colorspace(encoder, hasAlpha);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static LibHeif.Chroma GetChroma(IntPtr encoder, bool hasAlpha, int bitDepth)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					return Native.encoder_chroma(encoder, hasAlpha, bitDepth);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static bool Encode(IntPtr encoder, LibHeif.ImageHandle* handle, LibHeif.Image* image, byte** buffer, ulong* buffer_size)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					return Native.encode(encoder, handle, image, buffer, buffer_size);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void Free(IntPtr pointer)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					Native.free_pointer(pointer);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void UpdateDecodingOptions(IntPtr encoder, LibHeif.ImageHandle* handle, IntPtr decodingOptions)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
				case Architecture.X86:
					Native.encoder_update_decoding_options(encoder, handle, decodingOptions);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}
	}
}
