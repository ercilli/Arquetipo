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
            await _next(context);

            // Verifica si el código de estado de la respuesta es 204 (No Content)
            if (context.Response.StatusCode == 204)
            {
                // Si es 204, no intentes escribir en el cuerpo de la respuesta y termina la ejecución del middleware
                return;
            }

            // Si el código de estado no es 204, procede como normalmente
            // Verifica si model.HttpResponseBody es "-", asigna null a responseApi.Data; de lo contrario, asigna el valor de model.HttpResponseBody
            responseApi.Data = model.HttpResponseBody == "-" ? null : model.HttpResponseBody;

            responseApi.Meta = new Meta() { method = context.Request.Method, operation = context.Request.Path };

            await context.Response.WriteAsync(JsonSerializer.Serialize(responseApi));
        }
    }
}

