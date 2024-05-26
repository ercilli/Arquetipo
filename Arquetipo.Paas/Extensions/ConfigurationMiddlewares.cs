using Arquetipo.Paas.MiddlewareRegistration;
using Microsoft.AspNetCore.Builder;
namespace Arquetipo.Paas.Extensions
{
	public static class ConfigurationMiddlewares
	{
        public static IApplicationBuilder UsePaas(this IApplicationBuilder app)
        {
            var middlewareRegistry = new MiddlewareRegistry();

            foreach (var middlewareType in middlewareRegistry.GetOrderedMiddlewareTypes())
            {
                app.UseMiddleware(middlewareType);
            }

            return app;
        }
    }
}

