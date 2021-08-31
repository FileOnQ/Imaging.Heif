namespace FileOnQ.Imaging.Heif
{
	partial class LibHeif
	{
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
	}
}
