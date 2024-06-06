using System.Text.Json;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ResponseGenerator.Middlewares
{
    public class ResponseGeneratorMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseGeneratorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ResponseApi responseApi)
        {
            Console.WriteLine("Ingreso al middleware ResponseGenerator");

            await _next(context);

            await context.Response.WriteAsync(JsonSerializer.Serialize(responseApi));

            Console.WriteLine("Salgo del middleware ResponseGenerator");
        }
    }
}

