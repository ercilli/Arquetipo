using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Technical.Database
{
    public class DatabaseException : BaseException
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

