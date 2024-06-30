using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cors.Configuration.Extensions
{
    public static class CorsConfigurationExtension
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // Suponiendo que tienes un esquema de nomenclatura como CORS_POLICY_{n}_ORIGINS, etc.
                int i = 1;
                while (true)
                {
                    var origins = Environment.GetEnvironmentVariable($"CORS_POLICY_{i}_ORIGINS")?.Split(',');
                    if (origins == null || !origins.Any()) break; // No hay más políticas definidas

                    var methods = Environment.GetEnvironmentVariable($"CORS_POLICY_{i}_METHODS")?.Split(',');
                    var headers = Environment.GetEnvironmentVariable($"CORS_POLICY_{i}_HEADERS")?.Split(',');

                    options.AddPolicy($"CorsPolicy{i}", builder =>
                    {
                        builder.WithOrigins(origins)
                               .WithMethods(methods ?? new string[] { "GET", "POST" }) // Valores predeterminados
                               .WithHeaders(headers ?? new string[] { "Content-Type" }); // Valores predeterminados
                    });

                    i++;
                }
            });

            return services;
        }
    }
}

