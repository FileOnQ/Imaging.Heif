using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	partial class LibHeif
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
		public struct Error
		{
			public ErrorCode Code;
			public SubErrorCode SubCode;
			public IntPtr Message;
		}
	}
}
