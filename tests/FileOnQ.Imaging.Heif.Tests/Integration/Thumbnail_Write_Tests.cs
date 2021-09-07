using System.IO;
using FileOnQ.Imaging.Heif.Tests.Utilities;
using NUnit.Framework;

namespace FileOnQ.Imaging.Heif.Tests.Integration
{
	[TestFixture(TestData.Image5)]
	[Category(Constants.Category.Integration)]
	[Category(Constants.Category.FileIO)]
	public class Thumbnail_Write_Tests
	{
		readonly string input;
		readonly string output;
		readonly string hash;

		public Thumbnail_Write_Tests(string path)
		{
			hash = TestData.Integration.ThuumbnailSave.HashCodes[path];

			var assemblyDirectory = Path.GetDirectoryName(typeof(NoThumbnailTests).Assembly.Location) ?? string.Empty;
			input = Path.Combine(assemblyDirectory, path);

			var filename = Path.GetFileNameWithoutExtension(input);
			var directory = Path.GetDirectoryName(input) ?? string.Empty;
			output = Path.Combine(directory, $"{filename}.jpeg");
		}

		[OneTimeSetUp]
		public void Execute()
		{
			using (var image = new HeifImage(input))
			using (var thumbnail = image.Thumbnail())
			{
				thumbnail.Write(output);
			}
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			if (File.Exists(output))
				File.Delete(output);
		}

		[Test]
		public void Thumbnail_Write_FileExists_Test() =>
			Assert.IsTrue(File.Exists(output));

		[Test]
		public void Thumbnail_Write_Match_Test()
		{
			var buffer = File.ReadAllBytes(output);

			Assert.IsTrue(buffer.Length > 0);
			AssertUtilities.IsHashEqual(hash, buffer);
		}
    }
}
