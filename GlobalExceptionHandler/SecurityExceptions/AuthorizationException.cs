using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Security.Authorization
{
    public class AuthorizationException : BaseException
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string message) : base(message)
        {
        }

        public AuthorizationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

