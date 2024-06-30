using Arquetipo.Paas.MiddlewareRegistration;
using Microsoft.AspNetCore.Builder;
using Cors.Configuration.Extensions;
using Healthcheck.Configuration.Extensions;
using Swagger.Configuration.Extensions;

namespace Arquetipo.Paas.Extensions
{
	public static class ConfigurationPaaSMiddlewares
	{
        public static IApplicationBuilder UsePaas(this IApplicationBuilder app)
        {
            MiddlewareExtraPaaS(app);

            var middlewareRegistry = new MiddlewareRegistry();

            foreach (var middlewareType in middlewareRegistry.GetOrderedMiddlewareTypes())
            {
                app.UseMiddleware(middlewareType);
            }

            return app;
        }

        public static IApplicationBuilder MiddlewareExtraPaaS(this IApplicationBuilder app)
        {
            app.UseCorsConfiguration();
            app.UseBaseHealthChecks();
            app.UseSwaggerConfiguration();

            return app;
        }
    }
}

