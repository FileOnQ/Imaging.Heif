#if NET48_OR_GREATER
using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	static class Interop
	{
		[DllImport("kernel32.dll")]
		private static extern bool SetDllDirectory(string dllToLoad);

		internal static void UpdateDllSearchPath()
		{
			var binPath = new Uri(typeof(LibHeif).Assembly.CodeBase).LocalPath;
			var folder = System.IO.Path.GetDirectoryName(binPath);
			var runtime = $"runtimes\\win-{RuntimeInformation.ProcessArchitecture}\\native";
			var nativePath = System.IO.Path.Combine(folder, runtime);

			var loaded = SetDllDirectory(nativePath);
			if (!loaded)
				throw new HeifInteropException("Unable to set native path");
		}
	}
}
#endif