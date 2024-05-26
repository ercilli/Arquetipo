using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Tracing.Configuration.Services;

namespace Tracing.Configuration.Extensions
{
	public static class TracingConfigurationExtension
	{
        public static IServiceCollection AddTracingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddAspNetCoreInstrumentation()
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Poc-Opentalemetry"))
                .AddHttpClientInstrumentation()
                .AddJaegerExporter(o =>
                {
                    o.AgentHost = configuration["JAEGER_AGENT_HOST"] ?? "localhost";
                    o.AgentPort = int.Parse(configuration["JAEGER_AGENT_PORT"] ?? "6831");
                })
                .Build();

            Sdk.SetDefaultTextMapPropagator(new JaegerPropagator());

            return services;
        }
    }
}

