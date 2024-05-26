using System;
using Logging.Models.LoggingModels;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Models.Extensions
{
    public static class LoggingModelsExtension
    {
        public static IServiceCollection AddLoggingModel(this IServiceCollection services)
        {
            services.AddScoped<CommonLoggingModel>();
            services.AddScoped<InterceptorRequestLoggingModel>();
            services.AddScoped<InterceptorResponseLoggingModel>();
            services.AddScoped<RequestLoggingModel>();
            services.AddScoped<ResponseLoggingModel>();

            return services;
        }
    }
}

