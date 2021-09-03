using System.IO;
using NUnit.Framework;

namespace FileOnQ.Imaging.Heif.Tests.Integration
{
	[TestFixture("Images/20210224_023830752_iOS.heic")]
	[TestFixture("Images/20210224_024608242_iOS.heic")]
	[TestFixture("Images/20210224_024634111_iOS.heic")]
	[TestFixture("Images/20210224_032806886_iOS.heic")]
	[Category(Constants.Category.Integration)]
    public class NoThumbnailTests
    {
		readonly string input;

		public NoThumbnailTests(string path)
		{
			var assemblyDirectory = Path.GetDirectoryName(typeof(NoThumbnailTests).Assembly.Location) ?? string.Empty;
			input = Path.Combine(assemblyDirectory, path);
		}

		[Test]
		public void SaveThumbnail_Test()
		{
			var exception = Assert.Throws<HeifException>(() =>
			{
				using (var image = new HeifImage(input))
				using (var thumbnail = image.Thumbnail())
				{
					thumbnail.Write("output.jpeg");
				}
			});

			Assert.AreEqual(LibHeif.ErrorCode.NoThumbnail, exception.ErrorCode);
			Assert.AreEqual(LibHeif.SubErrorCode.heif_suberror_Unspecified, exception.ErrorSubCode);
			Assert.AreEqual("No thumbnail found in file", exception.Details);
			Assert.AreEqual("Heif image exception - No thumbnail found in file", exception.Message);
		}
    }
}
