using System;
using FileOnQ.Imaging.Heif;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var image = new HeifImage(@"20210821_095129.heic"))
			using (var thumb = image.Thumbnail())
			{
				thumb.Save("output", 90);
			}
        }
    }
}
