using System;
using BenchmarkDotNet.Running;

namespace FileOnQ.Imaging.Heif.Benchmarks
{
    class Program
    {
		public static string Input => "Images\\20210821_095129.heic";

		static void Main(string[] args)
        {
			Console.WriteLine("FileOnQ Imaging HEIF Benchmark tool");

			if (args.Length < 2 || args[0] != "-b")
			{
				Console.WriteLine("Available commands:");
				Console.WriteLine("\t-b benchmark to run (primary, thumbnail, etc.)");
				Console.WriteLine("\r\nExample: dotnet run -b thumbnail");
				return;
			}

			var benchmark = args[1].ToLower();
			switch (benchmark)
			{
				case "primary":
					Console.WriteLine("Starting Primary Image benchmarks . . .");
					PrimaryImage();
					break;
				case "thumbnail":
					Console.WriteLine("Starting Thumbnail benchmarks . . .");
					Thumbnail();
					break;
				default:
					Console.WriteLine($"Benchmark {benchmark} is not available");
					break;
			}

			Console.WriteLine("Benchmark completed");
		}

		static void PrimaryImage() => BenchmarkRunner.Run<PrimaryImage>();
		static void Thumbnail() => BenchmarkRunner.Run<Thumbnail>();
	}
}
