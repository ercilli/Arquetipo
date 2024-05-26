using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using ErrorHandling.Interfaces;

namespace ErrorHandling.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IExceptionHandler _exceptionHandler)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await _exceptionHandler.HandleExceptionAsync(ex, context);
            }
        }
    }
}
