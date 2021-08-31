using System;

namespace FileOnQ.Imaging.Heif
{
	public interface IHeifImage : IDisposable
	{
		IImage Thumbnail();
		IImage PrimaryImage();
	}
}
