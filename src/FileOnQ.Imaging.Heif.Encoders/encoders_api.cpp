#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <libheif/api/libheif/heif.h>

#include "encoders_api.h"
#include "encoder.h"
#include "encoder_jpeg.h"

Encoder* encoder_jpeg_init(int quality)
{
	return new JpegEncoder(quality);
}

heif_colorspace encoder_colorspace(Encoder* encoder, bool has_alpha)
{
	return encoder->colorspace(has_alpha);
}

heif_chroma encoder_chroma(Encoder* encoder, bool has_alpha, int bit_depth)
{
	return encoder->chroma(has_alpha, bit_depth);
}

bool encode(Encoder* encoder, const struct heif_image_handle* handle, const struct heif_image* image, unsigned char** buffer, unsigned long* buffer_size)
{
	return encoder->Encode(handle, image, buffer, buffer_size);
}

void encoder_update_decoding_options(Encoder* encoder, const struct heif_image_handle* handle, struct heif_decoding_options* options)
{
	encoder->UpdateDecodingOptions(handle, options);
}

void free_pointer(void* pointer)
{
	if (!pointer)
		return;

	free(pointer);
}