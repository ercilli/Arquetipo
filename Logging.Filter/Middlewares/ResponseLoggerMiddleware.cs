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
            await _next(context);

            await _responseLogger.LogResponseAsync();
        }
    }
}

