#pragma once

#include <iostream>
#include <libheif/api/libheif/heif.h>

#include "encoder_jpeg.h"

#ifdef ENCODERS_API
#define ENCODERS_API __declspec(dllexport)
#else
#define ENCODERS_API __declspec(dllimport)
#endif

extern "C" ENCODERS_API Encoder* encoder_jpeg_init(int quality);
extern "C" ENCODERS_API heif_colorspace encoder_colorspace(Encoder * encoder, bool has_alpha);
extern "C" ENCODERS_API heif_chroma encoder_chroma(Encoder * encoder, bool has_alpha, int bit_depth);
extern "C" ENCODERS_API bool encode(Encoder* encoder, const struct heif_image_handle* handle, const struct heif_image* image, unsigned char** buffer, unsigned long* buffer_size);
extern "C" ENCODERS_API void encoder_update_decoding_options(Encoder * encoder, const struct heif_image_handle* handle, struct heif_decoding_options* options);
extern "C" ENCODERS_API void free_pointer(void* pointer);