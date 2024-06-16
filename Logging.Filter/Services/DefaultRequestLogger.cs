using System;
using Logging.Filter.Abstracts;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging.Filter.Services
{
    public class DefaultRequestLogger : BaseRequestLogger
    {
        public DefaultRequestLogger(RequestLoggingModel model, ILogger<BaseRequestLogger> logger, IHttpContextAccessor contextAccessor) : base(model, logger, contextAccessor)
        {

        }

        protected override async Task LogAdditionalInfoAsync(HttpContext context)
        {
            await Task.CompletedTask;
        }

        protected override async Task ModifyModelBeforeLogging(HttpContext context)
        {
            await Task.CompletedTask;
        }
    }
}

