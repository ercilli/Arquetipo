using System;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using Logging.Filter.Interfaces;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Services
{
    public class RequestInspection : IRequestInspection
    {
        private readonly RequestLoggingModel _model;
        private readonly IHttpContextAccessor _contextAccessor;

        public RequestInspection(RequestLoggingModel model, IHttpContextAccessor contextAccessor)
        {
            _model = model;
            _contextAccessor = contextAccessor;
        }

        public async Task RequestExtractAsync()
        {
            var context = _contextAccessor.HttpContext;

            _model.LogType = "REQUEST";
            _model.IdChannel = GetIdChannel(context);
            _model.HttpRequestAddress = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";
            _model.HttpRequestQueryString = $"{context.Request.QueryString}";
            _model.HttpRequestMethod = $"{context.Request.Method}";
            _model.HttpRequestRemoteAddress = GetRemoteAdress(context);
            _model.HttpRequestHeader = GetAllRequestHeaders(context);
            _model.HttpRequestBody = await GetRequestBodyAsync(context);
        }

        private string GetIdChannel(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("id_channel", out var idChannelValue) && !string.IsNullOrEmpty(idChannelValue))
                return idChannelValue;

            return _model.IdChannel;
        }

        private string GetRemoteAdress(HttpContext context)
        {
            // Intenta obtener la dirección IP del encabezado X-Forwarded-For
            if (context.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor) && !string.IsNullOrEmpty(forwardedFor))
            {
                // Puede haber múltiples direcciones IP en el encabezado, separadas por comas
                var ipAddresses = forwardedFor.ToString().Split(',');
                // La primera dirección IP es la dirección del cliente original
                _model.HttpRequestRemoteAddress = ipAddresses.Length > 0 ? ipAddresses[0] : "";
            }
            else
            {
                // Si no hay encabezado X-Forwarded-For, obtén la dirección IP directamente del contexto
                // Esto puede no ser fiable si hay un proxy o balanceador de carga sin configurar X-Forwarded-For
                _model.HttpRequestRemoteAddress = context.Connection.RemoteIpAddress.ToString();
            }

            return _model.HttpRequestRemoteAddress;
        }

        private string GetAllRequestHeaders(HttpContext context)
        {
            var headersDict = new Dictionary<string, string>();

            foreach (var header in context.Request.Headers)
            {
                headersDict.Add(header.Key, header.Value);
            }

            return JsonSerializer.Serialize(headersDict, new JsonSerializerOptions { WriteIndented = true });
        }

        private async Task<string> GetRequestBodyAsync(HttpContext context)
        {
            // Asegúrate de que el cuerpo de la solicitud se pueda leer varias veces
            context.Request.EnableBuffering();

            // Guarda la posición actual del flujo para restaurarla después de leer
            var currentPosition = context.Request.Body.Position;

            using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
            {
                context.Request.Body.Position = 0;
                var body = await reader.ReadToEndAsync();
                // Restaura la posición del flujo para no interferir con el procesamiento de la solicitud
                context.Request.Body.Position = currentPosition;
                return body;
            }
        }
    }
}

