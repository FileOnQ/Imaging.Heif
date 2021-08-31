using System;

namespace FileOnQ.Imaging.Heif
{
	public interface IImage : IDisposable
	{
		void Save(string filename, int quality = 90);
	}
}
