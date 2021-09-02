using System;
using System.IO;
using System.Reflection;
using FileOnQ.Imaging.Heif;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var image = new HeifImage(GetFilePath()))
			using (var thumb = image.Thumbnail())
			{
				thumb.Save("output.jpeg", 90);
			}

			string GetFilePath()
			{
				var assemblyPath = new Uri(typeof(Program).Assembly.CodeBase).LocalPath;
				var directory = Path.GetDirectoryName(assemblyPath);
				return Path.Combine(directory, "20210821_095129.heic");
			}
        }
	}
}
