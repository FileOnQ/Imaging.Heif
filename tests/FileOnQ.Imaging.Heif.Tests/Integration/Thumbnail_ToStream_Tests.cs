﻿using System.IO;
using FileOnQ.Imaging.Heif.Tests.Utilities;
using NUnit.Framework;

namespace FileOnQ.Imaging.Heif.Tests.Integration
{
	[TestFixture(TestData.Image5)]
	[Category(Constants.Category.Integration)]
	[Category(Constants.Category.MemoryBuffer)]
	public class Thumbnail_ToStream_Tests
	{
		readonly string input;
		readonly string hash;
		Stream output;

		public Thumbnail_ToStream_Tests(string path)
		{
			hash = TestData.Integration.ThuumbnailSave.HashCodes[path];

			var assemblyDirectory = Path.GetDirectoryName(typeof(NoThumbnailTests).Assembly.Location) ?? string.Empty;
			input = Path.Combine(assemblyDirectory, path);
		}

		[OneTimeSetUp]
		public void Execute()
		{
			using (var image = new HeifImage(input))
			using (var thumbnail = image.Thumbnail())
			{
				output = thumbnail.ToStream();
			}
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			output?.Dispose();
			output = null;
		}

		[Test]
		public void Thumbnail_ToStream_NotNull_Test()
		{
			Assert.IsNotNull(output);
		}

		[Test]
		public void Thumbnail_ToStream_Match_Test()
		{
			byte[] buffer = new byte[0];
			using (var stream = new MemoryStream())
			{
				output.CopyTo(stream);
				buffer = stream.ToArray();
			}

			Assert.IsTrue(output.Length > 0);
			AssertUtilities.IsHashEqual(hash, buffer);
		}
    }
}
