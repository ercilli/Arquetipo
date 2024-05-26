using System;

namespace ErrorHandling.Exceptions
{
	public class BaseException : Exception
	{
        public string ErrorCode { get; }
        public string StatusCode { get; }

        public BaseException(string message, string errorCode, string statusCode)
            : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }
    }
}

