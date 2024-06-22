using System;
using GlobalExceptionHandler.Base;

namespace GlobalExceptionHandler.Technical.IO
{
    public class IOException : BaseException
    {
        public IOException()
        {
        }

        public IOException(string message) : base(message)
        {
        }

        public IOException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

