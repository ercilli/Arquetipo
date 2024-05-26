using System;
using Logging.Filter.Interfaces;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.AspNetCore;

namespace Logging.Filter.Abstracts
{
    public abstract class BaseRequestLogger : IRequestLogger
    {
        private readonly RequestLoggingModel _model;
        private readonly ILogger<BaseRequestLogger> _logger;

        protected BaseRequestLogger(RequestLoggingModel model, ILogger<BaseRequestLogger> logger)
        {
            _model = model;
            _logger = logger;
        }

        public async Task LogRequestAsync(HttpContext context)
        {
            // Llama a un método abstracto que las clases derivadas pueden utilizar para agregar logueo adicional
            var httpcontext = context;

            await LogAdditionalInfoAsync(httpcontext);

            await ModifyModelBeforeLogging(httpcontext);

            // Logueo de path, method, y URI aquí
            LogBasicRequestInfo();

        }

        protected void LogBasicRequestInfo()
        {
            using (_logger.BeginScope(_model.ToDictionary()))
            {
                _logger.LogInformation("Request Executed");
            }

        }

        protected abstract Task LogAdditionalInfoAsync(HttpContext context);
        protected abstract Task ModifyModelBeforeLogging(HttpContext context);
    }
}

