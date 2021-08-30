#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <libheif/heif.h>

#include "encoders_api.h"
#include "encoder.h"
#include "encoder_jpeg.h"

void encoder_jpeg_init(int quality, Encoder* encoder)
{
	encoder = new JpegEncoder(quality);
}

heif_colorspace encoder_colorspace(Encoder* encoder, bool has_alpha)
{
	return encoder->colorspace(has_alpha);
}

heif_chroma encoder_chroma(Encoder* encoder, bool has_alpha, int bit_depth)
{
	return encoder->chroma(has_alpha, bit_depth);
}

bool encode(Encoder* encoder, const struct heif_image_handle* handle, const struct heif_image* image, const std::string& filename)
{
	return encoder->Encode(handle, image, filename);
}

void encoder_free(Encoder* encoder)
{
	free(encoder);
}