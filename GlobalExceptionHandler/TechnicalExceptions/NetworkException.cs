using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Technical.Network
{
    public class NetworkException : BaseException
    {
        public NetworkException()
        {
        }

        public NetworkException(string message) : base(message)
        {
        }

        public NetworkException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

