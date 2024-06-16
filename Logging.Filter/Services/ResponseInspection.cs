using System;
using System.Text;
using System.Text.Json;
using Logging.Filter.Interfaces;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Logging.Filter.Services
{
	public class ResponseInspection : IResponseInspection
	{
        private readonly ResponseLoggingModel _model;
        private readonly IHttpContextAccessor _contextAccessor;

        public ResponseInspection(ResponseLoggingModel model, IHttpContextAccessor contextAccessor)
        {
            _model = model;
            _contextAccessor = contextAccessor;
        }

        public async Task ResponseExtractAsync(string body)
        {
            var context = _contextAccessor.HttpContext;

            _model.LogType = "RESPONSE";
            _model.HttpResponseStatusCode = $"{context?.Response.StatusCode}";
            _model.HttpResponseStatusPhrase = $"{ReasonPhrases.GetReasonPhrase(context.Response.StatusCode)}";
            _model.HttpResponseBody = body;
            _model.HttpResponseHeaders = GetAllResponseHeaders(context);
            _model.HttpDuration = "-";
        }

        private string GetAllResponseHeaders(HttpContext context)
        {
            var headersDict = new Dictionary<string, string>();

            foreach (var header in context.Response.Headers)
            {
                headersDict.Add(header.Key, header.Value);
            }

            return JsonSerializer.Serialize(headersDict, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}

