using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Healthcheck.Configuration.Extensions
{
	public static class ConfigurationMiddlewareHealthcheck
	{
        public static IApplicationBuilder UseBaseHealthChecks(this IApplicationBuilder app)
        {
            // Configura el endpoint de liveness para devolver siempre "healthy"
            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = _ => false, // No ejecuta ninguna comprobación específica
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("Healthy");
                }
            });

            // Configura el endpoint de readiness para devolver siempre "healthy" por defecto
            // Aquí puedes agregar lógica para configurar checks específicos en el futuro
            app.UseHealthChecks("/readiness", new HealthCheckOptions
            {
                Predicate = _ => false, // No ejecuta ninguna comprobación específica por ahora
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("Healthy");
                }
            });

            return app;
        }
    }
}

