using System.IO;
using FileOnQ.Imaging.Heif.Tests.Utilities;
using NUnit.Framework;

namespace FileOnQ.Imaging.Heif.Tests.Integration
{
	[TestFixture(TestData.Image1)]
	[TestFixture(TestData.Image2)]
	[TestFixture(TestData.Image3)]
	[TestFixture(TestData.Image4)]
	[TestFixture(TestData.Image5)]
	[Category(Constants.Category.Integration)]
	[Category(Constants.Category.MemoryBuffer)]
	public class PrimaryImage_ToSpan_Tests
	{
		readonly string input;
		readonly string hash;

		public PrimaryImage_ToSpan_Tests(string path)
		{
			hash = TestData.Integration.PrimaryImageSave.HashCodes[path];

			var assemblyDirectory = Path.GetDirectoryName(typeof(NoThumbnailTests).Assembly.Location) ?? string.Empty;
			input = Path.Combine(assemblyDirectory, path);
		}

		[Test]
		public void PrimaryImage_ToSpan_Match_Test()
		{
			// the span accesses native memory and must be used within the 
			// IDisposable context of IImage. Otherwise you will be attempting
			// to access deleted memory.

			using (var image = new HeifImage(input))
			using (var primary = image.PrimaryImage())
			{
				var output = primary.ToSpan();

				Assert.IsTrue(output.Length > 0);
				AssertUtilities.IsHashEqual(hash, output.ToArray());
			}
		}
    }
}
