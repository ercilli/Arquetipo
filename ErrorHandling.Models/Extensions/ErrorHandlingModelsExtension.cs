using System;
using ErrorHandling.Models.ErrorHandlingModels;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandling.Models.Extensions
{
	public static class ErrorHandlingModelsExtension
	{
        public static IServiceCollection AddErrorHandlingModel(this IServiceCollection services)
        {
            services.AddScoped<BaseErrorModel>();

            return services;
        }
    }
}

