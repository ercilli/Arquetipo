using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Architectural.Configuration
{
    public class ConfigurationException : BaseException
    {
        public ConfigurationException()
        {
        }

        public ConfigurationException(string message) : base(message)
        {
        }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

