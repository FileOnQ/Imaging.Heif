using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace FileOnQ.Imaging.Heif.Tests.Utilities
{
	public static class AssertUtilities
	{
		public static void IsHashEqual(string expectedHash, byte[] actual)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = sha256.ComputeHash(actual);
				var hash = BitConverter.ToString(bytes).Replace("-", string.Empty);

				Assert.AreEqual(expectedHash, hash, "Hash value does not match expected hash");
			}
		}
	}
}
