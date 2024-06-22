using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Architectural.DependencyInjection
{
    public class DependencyInjectionException : BaseException
    {
        public DependencyInjectionException()
        {
        }

        public DependencyInjectionException(string message) : base(message)
        {
        }

        public DependencyInjectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

