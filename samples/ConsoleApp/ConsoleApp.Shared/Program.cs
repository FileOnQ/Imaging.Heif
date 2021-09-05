using System;
using System.IO;
using FileOnQ.Imaging.Heif;

namespace ConsoleApp
{
	class Program
    {
        static void Main(string[] args)
        {
	        using (var image = new HeifImage(GetFilePath()))
	        {
		        try
		        {
			        using (var thumb = image.Thumbnail())
			        {
				        thumb.Write("output.jpeg", 90);
			        }
		        }
		        catch (HeifException ex)
		        {
			        if (ex.ErrorCode != LibHeif.ErrorCode.NoThumbnail)
				        throw;

			        using (var primaryImage = image.PrimaryImage())
			        {
				        primaryImage.Write("output.jpeg", 90);
			        }
		        }
	        }

	        string GetFilePath()
			{
				var assemblyPath = new Uri(typeof(Program).Assembly.Location).LocalPath;
				var directory = Path.GetDirectoryName(assemblyPath);
				return Path.Combine(directory, "20210224_032806886_iOS.heic");
			}
        }
	}
}
