using System;
using Logging.Filter.Interfaces;
using Logging.Filter.Services;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Middlewares
{
	public class ResponseInspectionMiddleware
	{
        private readonly RequestDelegate _next;

        public ResponseInspectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IResponseInspection _inspect)
        {
            // Captura el flujo original
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                // Reemplaza el flujo de la respuesta
                context.Response.Body = responseBody;

                // Continúa con la cadena de middleware
                await _next(context);

                // Leer el cuerpo de la respuesta
                responseBody.Seek(0, SeekOrigin.Begin);

                var body = await new StreamReader(responseBody).ReadToEndAsync();

                // Aquí es donde integrarías con tu clase RequestInspection para registrar la respuesta
                await _inspect.ResponseExtractAsync(context, body);

                // Vuelve a escribir el cuerpo de la respuesta al flujo original
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }
}

