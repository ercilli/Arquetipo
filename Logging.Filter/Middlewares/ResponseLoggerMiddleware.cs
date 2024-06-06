using System;
using Logging.Filter.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Middlewares
{
	public class ResponseLoggerMiddleware
	{
        private readonly RequestDelegate _next;

        public ResponseLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IResponseLogger _responseLogger)
        {
            Console.WriteLine("Ingreso al middleware ResponseLogger");
            await _next(context);
            var httpcontext = context;
            await _responseLogger.LogResponseAsync(httpcontext);
            Console.WriteLine("Salgo del middleware ResponseLogger");
        }
    }
}

