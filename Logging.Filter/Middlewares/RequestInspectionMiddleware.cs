using System;
using System.Net.Http;
using Logging.Filter.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Middlewares
{
    public class RequestInspectionMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestInspectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestInspection _inspect)
        {
            var httpcontext = context;

            await _inspect.RequestExtractAsync();

            await _next(context);
        }
    }
}

