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

        public async Task InvokeAsync(HttpContext context, IResponseBuilder responseBuilder)
        {
            await _next(context);

            // Verifica si el código de estado de la respuesta es 204 (No Content)
            if (context.Response.StatusCode == 204)
            {
                // Si es 204, no intentes escribir en el cuerpo de la respuesta y termina la ejecución del middleware
                return;
            }

            if (context.Items.TryGetValue("hadException", out var valor))
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(responseBuilder.BuildResponse()));
            }
        }
    }
}

