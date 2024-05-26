using Logging.Filter.Interfaces;
using Logging.Filter.Services;
using Logging.Models.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Filter.Extensions
{
	public static class LoggingFilterExtension
	{
        public static IServiceCollection AddLoggingFilter(this IServiceCollection services)
        {
            services.AddLoggingModel();
            services.AddScoped<IRequestLogger, DefaultRequestLogger>();
            services.AddScoped<IResponseLogger, DefaultResponseLogger>();
            services.AddScoped<IRequestInspection, RequestInspection>();
            services.AddScoped<IResponseInspection, ResponseInspection>();

            return services;
        }
	}
}

