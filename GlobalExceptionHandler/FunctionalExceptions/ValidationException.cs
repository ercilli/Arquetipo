using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Functional.Validation
{
    public class ValidationException : BaseException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

