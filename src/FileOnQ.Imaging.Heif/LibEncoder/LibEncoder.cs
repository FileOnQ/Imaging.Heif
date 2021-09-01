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
					return x64.encoder_jpeg_init(quality);
				case Architecture.X86:
					return x86.encoder_jpeg_init(quality);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static LibHeif.ColorSpace GetColorSpace(IntPtr encoder, bool hasAlpha)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.encoder_colorspace(encoder, hasAlpha);
				case Architecture.X86:
					return x86.encoder_colorspace(encoder, hasAlpha);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static LibHeif.Chroma GetChroma(IntPtr encoder, bool hasAlpha, int bitDepth)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.encoder_chroma(encoder, hasAlpha, bitDepth);
				case Architecture.X86:
					return x86.encoder_chroma(encoder, hasAlpha, bitDepth);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static bool Encode(IntPtr encoder, LibHeif.ImageHandle* handle, LibHeif.Image* image, string filename)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					return x64.encode(encoder, handle, image, filename);
				case Architecture.X86:
					return x86.encode(encoder, handle, image, filename);
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}

		internal static void Free(IntPtr encoder)
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case Architecture.X64:
					x64.encoder_free(encoder);
					break;
				case Architecture.X86:
					x86.encoder_free(encoder);
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
					x64.encoder_update_decoding_options(encoder, handle, decodingOptions);
					break;
				case Architecture.X86:
					x86.encoder_update_decoding_options(encoder, handle, decodingOptions);
					break;
				default:
					throw new NotSupportedException($"Current platform ({RuntimeInformation.ProcessArchitecture}) is not supported");
			}
		}
	}
}