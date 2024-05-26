using System;
using Logging.Interceptor.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Interceptor.Pom
{
	public static class LoggingInterceptorPomExtension
	{
        public static IServiceCollection AddLoggingInterceptorPom(this IServiceCollection services)
        {
          
            // Registra el LoggingInterceptorHandler para inyección de dependencias
            services.AddTransient<LoggingInterceptorHandlerPom>();

            // Configura un HttpClient que utiliza el LoggingInterceptorHandler
            services.AddHttpClient("Interceptor")
                    .AddHttpMessageHandler<LoggingInterceptorHandlerPom>();

            return services;
        }
    }
}

