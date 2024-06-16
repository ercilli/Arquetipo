using Logging.Configuration.Extensions;
using Logging.Filter.Extensions;
using ErrorHandling.Extensions;
using Logging.Interceptor.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResponseGenerator.Extensions;

namespace Arquetipo.Paas.Extensions
{
	public static class ConfigurationServices
	{
        public static IServiceCollection AddPaaS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddLoggingFilter();
            services.AddErrorHandling();
            services.AddLoggingInterceptor();
            services.AddResponseGenerator();
            services.AddSerilogServices(configuration);


            return services;
        }
	}
}

