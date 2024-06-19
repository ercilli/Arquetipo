using System;
using Serilog.Core;
using Serilog.Events;

namespace Logging.Configuration.Enrichers
{
    public class PropertyFilterEnricher : ILogEventEnricher
    {
        void ILogEventEnricher.Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // Listado de propiedades a ocultar
            var propertiesToHide = new[] { "TraceId", "SpanId", "RequestId", "Properties", "ActionName", "RequestPath", "MessageTemplate", "level" };

            foreach (var propName in propertiesToHide)
            {
                // Intenta remover las propiedades especificadas
                logEvent.RemovePropertyIfPresent(propName);
            }
        }
    }
}

