using System;
using Logging.Filter.Abstracts;
using Logging.Filter.Extensions;
using Logging.Filter.Interfaces;
using Logging.Filter.Services;
using Logging.Models.LoggingModels;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Filter.Pom
{
    public static class LoggingFilterPomExtension
    {
        public static IServiceCollection AddLoggingFilterPom(this IServiceCollection services)
        {
            // Si PomRequestLoggingModel deriva de RequestLoggingModel, regístralo aquí
            services.AddScoped<RequestLoggingModel,PomRequestLoggingModel >();

            // Registra PomRequestLogger para reemplazar cualquier BaseRequestLogger existente
            services.AddScoped<IRequestLogger, PomRequestLogger>();

            return services;
        }
    }
}

