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
                Console.WriteLine("Ingreso al middleware ErrorHandling");

                await _next(context);

                Console.WriteLine("Salgo del middleware ErrorHandling");
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: Ingreso al middleware ErrorHandling");

                await _exceptionHandler.HandleExceptionAsync(ex, context);

                Console.WriteLine("EXCEPTION: Salgo del middleware ErrorHandling");
            }
        }
    }
}
