using Logging.Configuration.Extensions;
using Logging.Filter.Extensions;
using ErrorHandling.Extensions;
using Logging.Interceptor.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResponseGenerator.Extensions;
using Serilog;
using Cors.Configuration.Extensions;
using Healthcheck.Configuration.Extensions;
using Swagger.Configuration.Extensions;

namespace Arquetipo.Paas.Extensions
{
	public static class ConfigurationServices
	{
        public static IServiceCollection AddPaaS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerConfiguration();
            services.AddBaseHealthChecks();
            services.AddCorsConfiguration();
            services.AddHttpContextAccessor();
            services.AddLoggingFilter();
            services.AddErrorHandling();
            services.AddLoggingInterceptor();
            services.AddResponseGenerator();
            services.AddSerilogServices(configuration);


            return services;
        }

        public static IServiceCollection AddBasePaaS(this IServiceCollection services, IConfiguration configuration, LoggerConfiguration loggerConfiguration)
        {
            services.AddSwaggerConfiguration();
            services.AddBaseHealthChecks();
            services.AddCorsConfiguration();
            services.AddHttpContextAccessor();
            services.AddLoggingFilter();
            services.AddErrorHandling();
            services.AddLoggingInterceptor();
            services.AddResponseGenerator();
            services.AddSerilogServices(configuration, loggerConfiguration);


            return services;
        }
    }
}

