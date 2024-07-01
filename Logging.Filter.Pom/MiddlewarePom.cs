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

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Ingreso al middleware Filter POM");
            Console.WriteLine("Ingreso al middleware Filter POM");
            await _next(context);
            _logger.LogInformation("Salgo del middleware Filter POM");
            Console.WriteLine("Salgo del middleware Filter POM");
        }
    }
}

