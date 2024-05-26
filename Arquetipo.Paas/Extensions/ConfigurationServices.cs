using Logging.Configuration.Extensions;
using Logging.Filter.Extensions;
using ErrorHandling.Extensions;
using Logging.Interceptor.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arquetipo.Paas.Extensions
{
	public static class ConfigurationServices
	{
        public static IServiceCollection AddPaaS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddErrorHandling();
            services.AddSerilogServices(configuration);
            services.AddLoggingFilter();
            services.AddLoggingInterceptor();

            return services;
        }
	}
}

