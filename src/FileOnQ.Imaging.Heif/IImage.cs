using System;

namespace FileOnQ.Imaging.Heif
{
	public interface IImage : IDisposable
	{
		void Write(string filename, int quality = 90);
		byte[] ToArray(int quality = 90);
	}
}
