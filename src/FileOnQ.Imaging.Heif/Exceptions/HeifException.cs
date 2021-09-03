using System;
using System.Runtime.InteropServices;

namespace FileOnQ.Imaging.Heif
{
	public class HeifException : Exception
	{
		const string ErrorMessage = "Heif image exception - {0}";
		public LibHeif.ErrorCode ErrorCode { get; }
		public LibHeif.SubErrorCode ErrorSubCode { get; }
		public string Details { get; }

		public HeifException(Error error)
			: base(string.Format(ErrorMessage, error.Message))
		{
			ErrorCode = error.Code;
			ErrorSubCode = error.SubCode;
			Details = error.Message;
		}

		public HeifException(Exception exception, Error error)
			: base(string.Format(ErrorMessage, error.Message), exception)
		{
			ErrorCode = error.Code;
			ErrorSubCode = error.SubCode;
			Details = error.Message;
		}

		internal HeifException(LibHeif.Error error)
			: this(new Error
			{
				Code = error.Code, 
				SubCode = error.SubCode, 
				Message = Marshal.PtrToStringAnsi(error.Message)
			})
		{
		}
		
		public struct Error
		{
			public LibHeif.ErrorCode Code;
			public LibHeif.SubErrorCode SubCode;
			public string Message;
		}
	}
}