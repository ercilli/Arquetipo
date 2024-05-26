using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Logging.Interceptor.Services;
using Logging.Models.LoggingModels;

namespace Logging.Interceptor.Extensions
{
    public static class LoggingInterceptorExtension
    {
        public static IServiceCollection AddLoggingInterceptor(this IServiceCollection services)
        {
            // Opcional: Registra los modelos si aún no están configurados en IServiceCollection
            services.AddSingleton<InterceptorRequestLoggingModel>();
            services.AddSingleton<InterceptorResponseLoggingModel>();

            // Registra el LoggingInterceptorHandler para inyección de dependencias
            services.AddTransient<LoggingInterceptorHandler>();

            // Configura un HttpClient que utiliza el LoggingInterceptorHandler
            services.AddHttpClient("Interceptor")
                    .AddHttpMessageHandler<LoggingInterceptorHandler>();

            return services;
        }
    }
}

