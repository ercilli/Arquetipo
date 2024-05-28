using System;
using ErrorHandling.Interfaces;
using ErrorHandling.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandling.Extensions
{
	public static class ErrorHandlingExtension
	{
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            services.AddScoped<IExceptionHandler, DefaultExceptionHandler>();
            
            return services;
        }
    }
}

