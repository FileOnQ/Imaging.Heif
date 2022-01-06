namespace FileOnQ.Imaging.Heif.Tests
{
	public static partial class Constants
	{
		public static class Category
		{
			// Defines test that complete full End to End testing
			public const string Integration = "Integration";

			// Defines test that validates a specific function or unit of work.
			public const string Unit = "Unit";

			// Defines integration tests that use the memory buffer APIs
			public const string MemoryBuffer = "MemoryBuffer";

			// Defines integration tests that use the File IO APIs
			public const string FileIO = "FileIO";
		}
	}
}
