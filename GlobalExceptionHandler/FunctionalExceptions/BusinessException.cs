using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Functional.Business
{
    public class BusinessException : BaseException
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

