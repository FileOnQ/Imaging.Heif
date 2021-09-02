using System;

namespace FileOnQ.Imaging.Heif
{
	public class HeifInteropException : Exception
	{
		const string ErrorMessage = "Error when interoping with native assemblies - {0}";
		
		public HeifInteropException(string message) 
			: base(string.Format(ErrorMessage, message))
		{
		}
	}
}