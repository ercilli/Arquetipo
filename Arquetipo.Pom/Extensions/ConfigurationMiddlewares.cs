using System;
using Arquetipo.Paas.MiddlewareRegistration;
using Logging.Filter.Pom;
using Microsoft.AspNetCore.Builder;

namespace Arquetipo.Pom.Extensions
{
	public static class ConfigurationMiddlewares
	{
        public static IApplicationBuilder UsePOM(this IApplicationBuilder app)
        {
            var middlewareRegistry = new MiddlewareRegistry();

            middlewareRegistry.RegisterMiddlewareAtPosition(typeof(MiddlewarePom), 0);

            foreach (var middlewareType in middlewareRegistry.GetOrderedMiddlewareTypes())
            {
                app.UseMiddleware(middlewareType);
            }

            return app;
        }
    }
}

