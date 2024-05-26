using System;
using Serilog.Core;
using Serilog.Events;

namespace Logging.Configuration.Enrichers
{
    public class DefaultLogTypeEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (!logEvent.Properties.ContainsKey("LOG_TYPE"))
            {
                LogEventProperty defaultLogType = propertyFactory.CreateProperty("log_type", "DEFAULT");
                logEvent.AddPropertyIfAbsent(defaultLogType);
            }
        }
    }
}

