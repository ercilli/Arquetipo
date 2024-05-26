using System;
using Logging.Filter.Abstracts;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging.Filter.Services
{
	public class DefaultResponseLogger : BaseResponseLogger
	{
        public DefaultResponseLogger(ResponseLoggingModel model, ILogger<BaseResponseLogger> logger) : base(model, logger)
        {
        }

        protected override async Task LogAdditionalInfoAsync(HttpContext context)
        {
            await Task.CompletedTask;
        }
    }
}

