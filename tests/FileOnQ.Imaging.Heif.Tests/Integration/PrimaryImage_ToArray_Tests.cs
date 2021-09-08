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
	public class PrimaryImage_ToArray_Tests
	{
		readonly string input;
		readonly string hash;
		byte[] output;

		public PrimaryImage_ToArray_Tests(string path)
		{
			hash = TestData.Integration.PrimaryImageSave.HashCodes[path];

			var assemblyDirectory = Path.GetDirectoryName(typeof(NoThumbnailTests).Assembly.Location) ?? string.Empty;
			input = Path.Combine(assemblyDirectory, path);
		}

		[OneTimeSetUp]
		public void Execute()
		{
			using (var image = new HeifImage(input))
			using (var primary = image.PrimaryImage())
			{
				output = primary.ToArray();
			}
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			output = null;
		}

		[Test]
		public void PrimaryImage_ToArray_NotNull_Test()
		{
			Assert.IsNotNull(output);
		}

		[Test]
		public void PrimaryImage_ToArray_Match_Test()
		{
			Assert.IsTrue(output.Length > 0);
			AssertUtilities.IsHashEqual(hash, output);
		}
    }
}
