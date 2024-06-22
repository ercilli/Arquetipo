using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Security.Authentication
{
    public class AuthenticationException : BaseException
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

