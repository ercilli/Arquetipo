using System;
using Logging.Filter.Interfaces;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging.Filter.Abstracts
{
	public abstract class BaseResponseLogger : IResponseLogger
	{
        private readonly ResponseLoggingModel _model;
        private readonly ILogger<BaseResponseLogger> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        protected BaseResponseLogger(ResponseLoggingModel model, ILogger<BaseResponseLogger> logger, IHttpContextAccessor contextAccessor)
        {
            _model = model;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public async Task LogResponseAsync()
        {
            var context = _contextAccessor.HttpContext;
            // Logueo de path, method, y URI aquí
            LogBasicResponseInfo();

            // Llama a un método abstracto que las clases derivadas pueden utilizar para agregar logueo adicional
            await LogAdditionalInfoAsync(context);
        }

        protected void LogBasicResponseInfo()
        {
            using (_logger.BeginScope(_model.ToDictionary()))
            {
                _logger.LogInformation("Response Executed");
            }
        }

        protected abstract Task LogAdditionalInfoAsync(HttpContext context);
    }
}

