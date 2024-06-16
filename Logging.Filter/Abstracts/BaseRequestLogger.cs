using Logging.Filter.Interfaces;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Logging.Filter.Abstracts
{
    public abstract class BaseRequestLogger : IRequestLogger
    {
        private readonly RequestLoggingModel _model;
        private readonly ILogger<BaseRequestLogger> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        protected BaseRequestLogger(RequestLoggingModel model, ILogger<BaseRequestLogger> logger, IHttpContextAccessor contextAccessor)
        {
            _model = model;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public async Task LogRequestAsync()
        {
            // Llama a un método abstracto que las clases derivadas pueden utilizar para agregar logueo adicional
            var httpcontext = _contextAccessor.HttpContext;

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

