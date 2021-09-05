using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;

namespace FileOnQ.Imaging.Heif.Benchmarks
{
	[SimpleJob(RuntimeMoniker.Net50, launchCount: 1, invocationCount: 1)]
	[NativeMemoryProfiler]
	[MemoryDiagnoser]
	[JsonExporterAttribute.Full]
	public class Thumbnail
	{
		readonly string filePath;
		readonly string output;

		public Thumbnail()
		{
			var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
			filePath = Path.Combine(assemblyDirectory, Program.Input);
			if (!File.Exists(filePath))
				throw new FileNotFoundException(filePath);

			output = Path.Combine(assemblyDirectory, "output.jpeg");
		}

		[Benchmark]
		public void Thumbnail_Write()
		{
			using (var image = new HeifImage(filePath))
			using (var thumbnail = image.Thumbnail())
			{
				thumbnail.Write(output);
			}

			File.Delete(output);
		}
	}
}
