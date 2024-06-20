using System;
using Serilog.Core;
using Serilog.Events;

namespace Logging.Configuration.Pom
{
    public class EnricherPom : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName", Environment.MachineName));
        }
    }
}

