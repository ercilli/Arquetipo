using Serilog.Core;
using Serilog.Events;
using System.Diagnostics;

public class TraceIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var activity = Activity.Current;
        if (activity != null)
        {
            var traceId = activity.TraceId.ToString();
            var spanId = activity.SpanId.ToString();
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("trace_id", traceId));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("span_id", spanId));
        }
    }
}
