using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Healthcheck.Configuration.Extensions
{
    public static class HealthcheckConfigurationExtension
    {
        public static IServiceCollection AddBaseHealthChecks(this IServiceCollection services)
        {
            // Agrega los health checks aquí
            services.AddHealthChecks();

            return services;
        }
    }
}

