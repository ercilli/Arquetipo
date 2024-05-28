using Microsoft.Extensions.DependencyInjection;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ResponseGenerator.Models.Extensions
{
	public static class ResponseGeneratorModelsExtension
	{
        public static IServiceCollection AddResponseGeneratorModels(this IServiceCollection services)
        {
            services.AddScoped<BaseErrorModel>();

            return services;
        }
    }
}

