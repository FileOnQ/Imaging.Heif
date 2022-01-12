using System;
using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;

namespace FileOnQ.Imaging.Heif.Benchmarks
{
#if NET48
	[SimpleJob(RuntimeMoniker.Net48, launchCount: 1, invocationCount: 1)]
#elif NET5_0
	[SimpleJob(RuntimeMoniker.Net50, launchCount: 1, invocationCount: 1)]
#elif NET6_0
	[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, invocationCount: 1)]
#endif
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

		[Benchmark]
		public byte[] Thumbnail_ToArray()
		{
			using (var image = new HeifImage(filePath))
			using (var thumbnail = image.Thumbnail())
			{
				return thumbnail.ToArray();
			}
		}

		[Benchmark]
		public ReadOnlySpan<byte> Thumbnail_ToSpan()
		{
			using (var image = new HeifImage(filePath))
			using (var thumbnail = image.Thumbnail())
			{
				return thumbnail.ToSpan();
			}
		}

		[Benchmark]
		public Stream Thumbnail_ToStream()
		{
			using (var image = new HeifImage(filePath))
			using (var thumbnail = image.Thumbnail())
			{
				return thumbnail.ToStream();
			}
		}
	}
}
