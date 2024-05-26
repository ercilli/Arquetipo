using System;
using Logging.Filter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging.Filter.Pom
{
	public class MiddlewarePom
	{
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewarePom> _logger;

        public MiddlewarePom(RequestDelegate next, ILogger<MiddlewarePom> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IRequestInspection _inspect)
        {
            _logger.LogInformation("Log POM Request");
            await _next(context);
            _logger.LogInformation("Log POM Response");

        }
    }
}

