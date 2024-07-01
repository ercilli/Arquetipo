using System.Text.Json;
using Logging.Models.LoggingModels;
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

        public async Task InvokeAsync(HttpContext context, ResponseApi responseApi, ResponseLoggingModel model)
        {
            Console.WriteLine("Ingreso al middleware ResponseGenerator");

            await _next(context);

            responseApi.Data = model.HttpResponseBody;

            await context.Response.WriteAsync(JsonSerializer.Serialize(responseApi));

            Console.WriteLine("Salgo del middleware ResponseGenerator");
        }
    }
}

