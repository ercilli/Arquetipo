using System;
using System.Text.Json;
using Logging.Models.LoggingModels;
using Microsoft.Extensions.Logging;

namespace Logging.Interceptor.Services
{
	public class LoggingInterceptorHandler : DelegatingHandler
	{
        private readonly ILogger<LoggingInterceptorHandler> _logger;
        private readonly InterceptorRequestLoggingModel _requestModel;
        private readonly InterceptorResponseLoggingModel _responseModel;


        public LoggingInterceptorHandler(ILogger<LoggingInterceptorHandler> logger, InterceptorRequestLoggingModel requestModel, InterceptorResponseLoggingModel responseModel)
        {
            _logger = logger;
            _requestModel = requestModel;
            _responseModel = responseModel;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContext = request;
            await InspectInterceptorRequest(requestContext);
            LogRequest();
            var response = await base.SendAsync(request, cancellationToken);
            var responseContext = response;
            await InspectInterceptorResponse(requestContext);
            LogResponse();

            return response;
        }

        private async Task InspectInterceptorRequest(HttpRequestMessage request)
        {
            request.Headers.Add("paas","example");
            _requestModel.LogType = "OUTGOING_REQUEST";
            _requestModel.OutgoingHttpRequestHeaders = GetAllRequestHeadersToJson(request);
            _requestModel.OutgoingHttpRequestBody = await GetRequestBodyAsync(request);
        }

        private async Task InspectInterceptorResponse(HttpRequestMessage request)
        {
            _responseModel.LogType = "OUTGOING_RESPONSE";
        }

        private static async Task<string> GetRequestBodyAsync(HttpRequestMessage request)
        {
            // Verifica si el request tiene contenido
            if (request.Content == null) return string.Empty;

            // Crea un MemoryStream para copiar el contenido del body
            using (var memStream = new MemoryStream())
            {
                // Copia el contenido del request al MemoryStream
                await request.Content.CopyToAsync(memStream);

                // Establece la posición en cero para leer desde el inicio
                memStream.Position = 0;

                // Lee el contenido del MemoryStream
                var requestBody = await new StreamReader(memStream).ReadToEndAsync();

                // Reestablece la posición en cero para permitir que otros procesos lean el stream
                memStream.Position = 0;

                // Reemplaza el contenido del request con el MemoryStream para que otros procesos puedan leerlo
                request.Content = new StreamContent(memStream);

                return requestBody;
            }
        }

        private static string GetAllRequestHeadersToJson(HttpRequestMessage request)
        {
            var headers = request.Headers
                .Concat(request.Content?.Headers ?? Enumerable.Empty<KeyValuePair<string, IEnumerable<string>>>())
                .ToDictionary(header => header.Key, header => string.Join(", ", header.Value));

            return JsonSerializer.Serialize(headers, new JsonSerializerOptions { WriteIndented = true });
        }

        protected virtual void LogRequest()
        {
            using (_logger.BeginScope(_requestModel.ToDictionary()))
            {
                _logger.LogInformation("Outgoing Request Executed");
            }
        }

        protected virtual void LogResponse()
        {
            using (_logger.BeginScope(_responseModel.ToDictionary()))
            {
                _logger.LogInformation("Outgoing Response Executed");
            }
        }
    }
}

