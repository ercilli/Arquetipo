using System;
using ErrorHandling.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ErrorHandling.Pom
{
	public static class ErrorHandlingPomExtension
	{
        public static IServiceCollection AddErrorHandlingPom(this IServiceCollection services)
        {
            // Si PomRequestLoggingModel deriva de RequestLoggingModel, regístralo aquí
            services.AddScoped<BaseErrorModel, BaseErrorPomModel>();

            // Registra PomRequestLogger para reemplazar cualquier BaseRequestLogger existente
            services.AddScoped<IExceptionHandler, PomDefaultExtensionHandler>();

            return services;
        }
    }
}

