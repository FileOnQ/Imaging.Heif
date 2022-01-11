#if NET48_OR_GREATER
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	static class Interop
	{
		[DllImport("kernel32.dll")]
		private static extern bool SetDllDirectory(string dllToLoad);

		private static bool loaded;

		internal static void UpdateDllSearchPath()
		{
			if (loaded)
				return;

			var binPath = new Uri(typeof(LibHeif).Assembly.CodeBase).LocalPath;
			var folder = Path.GetDirectoryName(binPath);
			var runtime = $"runtimes\\win-{RuntimeInformation.ProcessArchitecture}\\native";
			var nativePath = Path.Combine(folder, runtime);

			loaded = SetDllDirectory(nativePath);
			if (!loaded)
				throw new HeifInteropException("Unable to set native path");
		}
	}
}
#endif