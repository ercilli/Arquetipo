using System;
using Logging.Filter.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Middlewares
{
	public class RequestLoggerMiddleware
	{
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestLogger _requestLogger)
        {
            Console.WriteLine("Ingreso al middleware RequestLogger");
            var httpcontext = context;
            await _requestLogger.LogRequestAsync(context);
            await _next(context);
            Console.WriteLine("Salgo del middleware RequestLogger");
        }
    }
}

