using Microsoft.Extensions.DependencyInjection;
using ResponseGenerator.Models.Extensions;

namespace ResponseGenerator.Extensions
{
	public static class ResponseGeneratorExtension
	{
        public static IServiceCollection AddResponseGenerator(this IServiceCollection services)
        {
            services.AddResponseGeneratorModels();

            return services;
        }
    }
}

