using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	public unsafe class HeifImage : IDisposable
    {
		LibHeifContext.Context* heifContext;
		public HeifImage(string file)
		{
			heifContext = LibHeifContext.heif_context_alloc();
			var error = LibHeifContext.heif_context_read_from_file(heifContext, file, IntPtr.Zero);
			if (error.Code != LibHeifContext.ErrorCode.Ok)
				throw new Exception(Marshal.PtrToStringAnsi(error.Message));

			LibHeifContext.ImageHandle* imageHandle;
			var imageError = LibHeifContext.heif_context_get_primary_image_handle(heifContext, &imageHandle);

			var numberOfThumbnails = LibHeifContext.heif_image_handle_get_number_of_thumbnails(imageHandle);
			if (numberOfThumbnails > 0)
			{
				var itemIds = new uint[numberOfThumbnails];
				fixed (uint* ptr = itemIds)
				{
					LibHeifContext.heif_image_handle_get_list_of_thumbnail_IDs(imageHandle, ptr, numberOfThumbnails);
				}

				// no idea why this is failing
				LibHeifContext.ImageHandle* thumbHandle;
				var thumbError = LibHeifContext.heif_image_handle_get_thumbnail(imageHandle, itemIds[0], &thumbHandle);
				if (thumbError.Code != LibHeifContext.ErrorCode.Ok)
					throw new Exception(Marshal.PtrToStringAnsi(thumbError.Message));

				Encode(thumbHandle);
			}
			else
			{
				Encode(imageHandle);
			}

			void Encode(LibHeifContext.ImageHandle* handle)
			{
				var hasAlpha = LibHeifContext.heif_image_handle_has_alpha_channel(handle) == 1;
				var encoder = LibEncoder.InitJpegEncoder(90);
				var options = LibHeifContext.heif_decoding_options_alloc();
				LibEncoder.UpdateDecodingOptions(encoder, handle, options);

				var bitDepth = LibHeifContext.heif_image_handle_get_luma_bits_per_pixel(handle);
				if (bitDepth < 0)
				{
					LibHeifContext.heif_decoding_options_free(options);
					LibHeifContext.heif_image_handle_release(handle);
					throw new Exception("Input image has undefined bit-dept");
				}

				LibHeifContext.Image* outputImage;
				var decodeError = LibHeifContext.heif_decode_image(
					handle,
					&outputImage,
					LibEncoder.GetColorSpace(encoder, hasAlpha),
					LibEncoder.GetChroma(encoder, hasAlpha, bitDepth),
					options);

				LibHeifContext.heif_decoding_options_free(options);

				if (decodeError.Code != LibHeifContext.ErrorCode.Ok)
				{
					LibHeifContext.heif_image_handle_release(handle);
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
				LibHeifContext.heif_context_free(heifContext);
				heifContext = null;
			}

			isDisposed = true;
		}
	}

	public static unsafe class LibHeifContext
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
		internal static extern int heif_image_handle_get_list_of_thumbnail_IDs(ImageHandle* handle, uint *itemIds, int count);

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

		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct Context
		{
			public IntPtr Value;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct ImageHandle
		{
			public IntPtr Image;
			public IntPtr Context;
		}


		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct Error
		{
			public ErrorCode Code;
			public SubErrorCode SubCode;
			public IntPtr Message;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct EncoderDescriptor
		{
			public EncoderPlugin* Plugin;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct EncoderPlugin
		{
			public int ApiVersion;
			public CompressionFormat CompressionFormat;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct Image
		{
			public IntPtr PixelImage;
		}

		public enum ErrorCode
		{
			/// <summary>
			/// Everything ok, no error occurred.
			/// </summary>
			Ok = 0,

			/// <summary>
			/// Input file does not exist.
			/// </summary>
			InputDoesNotExist = 1,

			/// <summary>
			/// Error in input file. Corrupted or invalid content.
			/// </summary>
			InvalidInput = 2,

			/// <summary>
			/// Input file type is not supported.
			/// </summary>
			UnsupportedFileType = 3,

			/// <summary>
			/// Image requires an unsupported decoder feature.
			/// </summary>
			UnsupportedFeature = 4,

			/// <summary>
			/// Library API has been used in an invalid way.
			/// </summary>
			UsageError = 5,

			/// <summary>
			/// Could not allocate enough memory.
			/// </summary>
			MemoryAllocationError = 6,

			/// <summary>
			/// The decoder plugin generated an error
			/// </summary>
			DecoderPluginError = 7,

			/// <summary>
			/// The encoder plugin generated an error
			/// </summary>
			EncoderPluginError = 8,

			/// <summary>
			/// Error during encoding or when writing to the output
			/// </summary>
			EncodingError = 9,

			/// <summary>
			/// Application has asked for a color profile type that does not exist
			/// </summary>
			ColorProfileDoesNotExist = 10
		}

		public enum SubErrorCode
		{
			// no further information available
			heif_suberror_Unspecified = 0,

			// --- Invalid_input ---

			// End of data reached unexpectedly.
			heif_suberror_End_of_data = 100,

			// Size of box (defined in header) is wrong
			heif_suberror_Invalid_box_size = 101,

			// Mandatory 'ftyp' box is missing
			heif_suberror_No_ftyp_box = 102,

			heif_suberror_No_idat_box = 103,

			heif_suberror_No_meta_box = 104,

			heif_suberror_No_hdlr_box = 105,

			heif_suberror_No_hvcC_box = 106,

			heif_suberror_No_pitm_box = 107,

			heif_suberror_No_ipco_box = 108,

			heif_suberror_No_ipma_box = 109,

			heif_suberror_No_iloc_box = 110,

			heif_suberror_No_iinf_box = 111,

			heif_suberror_No_iprp_box = 112,

			heif_suberror_No_iref_box = 113,

			heif_suberror_No_pict_handler = 114,

			// An item property referenced in the 'ipma' box is not existing in the 'ipco' container.
			heif_suberror_Ipma_box_references_nonexisting_property = 115,

			// No properties have been assigned to an item.
			heif_suberror_No_properties_assigned_to_item = 116,

			// Image has no (compressed) data
			heif_suberror_No_item_data = 117,

			// Invalid specification of image grid (tiled image)
			heif_suberror_Invalid_grid_data = 118,

			// Tile-images in a grid image are missing
			heif_suberror_Missing_grid_images = 119,

			heif_suberror_Invalid_clean_aperture = 120,

			// Invalid specification of overlay image
			heif_suberror_Invalid_overlay_data = 121,

			// Overlay image completely outside of visible canvas area
			heif_suberror_Overlay_image_outside_of_canvas = 122,

			heif_suberror_Auxiliary_image_type_unspecified = 123,

			heif_suberror_No_or_invalid_primary_item = 124,

			heif_suberror_No_infe_box = 125,

			heif_suberror_Unknown_color_profile_type = 126,

			heif_suberror_Wrong_tile_image_chroma_format = 127,

			heif_suberror_Invalid_fractional_number = 128,

			heif_suberror_Invalid_image_size = 129,

			heif_suberror_Invalid_pixi_box = 130,

			heif_suberror_No_av1C_box = 131,

			heif_suberror_Wrong_tile_image_pixel_depth = 132,


			// --- Memory_allocation_error ---

			// A security limit preventing unreasonable memory allocations was exceeded by the input file.
			// Please check whether the file is valid. If it is, contact us so that we could increase the
			// security limits further.
			heif_suberror_Security_limit_exceeded = 1000,


			// --- Usage_error ---

			// An item ID was used that is not present in the file.
			heif_suberror_Nonexisting_item_referenced = 2000, // also used for Invalid_input

			// An API argument was given a NULL pointer, which is not allowed for that function.
			heif_suberror_Null_pointer_argument = 2001,

			// Image channel referenced that does not exist in the image
			heif_suberror_Nonexisting_image_channel_referenced = 2002,

			// The version of the passed plugin is not supported.
			heif_suberror_Unsupported_plugin_version = 2003,

			// The version of the passed writer is not supported.
			heif_suberror_Unsupported_writer_version = 2004,

			// The given (encoder) parameter name does not exist.
			heif_suberror_Unsupported_parameter = 2005,

			// The value for the given parameter is not in the valid range.
			heif_suberror_Invalid_parameter_value = 2006,


			// --- Unsupported_feature ---

			// Image was coded with an unsupported compression method.
			heif_suberror_Unsupported_codec = 3000,

			// Image is specified in an unknown way, e.g. as tiled grid image (which is supported)
			heif_suberror_Unsupported_image_type = 3001,

			heif_suberror_Unsupported_data_version = 3002,

			// The conversion of the source image to the requested chroma / colorspace is not supported.
			heif_suberror_Unsupported_color_conversion = 3003,

			heif_suberror_Unsupported_item_construction_method = 3004,


			// --- Encoder_plugin_error ---

			heif_suberror_Unsupported_bit_depth = 4000,


			// --- Encoding_error ---

			heif_suberror_Cannot_write_output_data = 5000,
		}

		public enum CompressionFormat
		{
			Undefined = 0,
			Hevc = 1,
			Avc = 2,
			Jpeg = 3,
			Av1 = 4
		}

		public enum ColorSpace
		{
			Undefined = 99,
			YCbCr = 0,
			Rgb = 1,
			MonoChrome = 2
		}

		public enum Chroma
		{
			Undefined = 99,
			Monochrome = 0,
			Chroma_420 = 1,
			Chroma_422 = 2,
			Chroma_444 = 3,
			Interleaved_RGB = 10,
			Interleaved_RGBA = 11,
			Interleaved_RRGGBB_BE = 12,
			Interleaved_RRGGBBAA_BE = 13,
			Interleaved_RRGGBB_LE = 14,
			Interleaved_RRGGBBAA_LE = 15
		}
	}
}
