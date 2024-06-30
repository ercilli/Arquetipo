using System;
using Microsoft.AspNetCore.Builder;

namespace Cors.Configuration.Extensions
{
    public static class ConfigurationMiddlewareCors
    {
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors();

            return app;
        }
    }
}

