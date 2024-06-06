using Logging.Filter.Pom;
using Logging.Interceptor.Pom;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Arquetipo.Paas.Extensions;
using ErrorHandling.Pom;

namespace Arquetipo.Pom.Extensions
{
	public static class ConfigurationServices
	{
        public static IServiceCollection AddPOM(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLoggingInterceptorPom(); //TODO entender por que si o si tengo que agregar primero el pom y luego el paas para interceptor
            services.AddPaaS(configuration);
            services.AddLoggingFilterPom();
            services.AddErrorHandlingPom();

            return services;
        }
	}
}

