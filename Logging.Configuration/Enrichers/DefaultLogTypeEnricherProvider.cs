using Logging.Configuration.Enrichers;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Serilog.Events;

namespace Logging.Configuration.Enrichers
{
    public class DefaultLogTypeEnricherProvider : ILogEventEnricher
    {
        private readonly DefaultLogTypeEnricher _enricher;

        public DefaultLogTypeEnricherProvider(IServiceProvider serviceProvider)
        {
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _enricher = new DefaultLogTypeEnricher(httpContextAccessor);
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _enricher.Enrich(logEvent, propertyFactory);
        }
    }
}


