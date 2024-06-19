using Logging.Configuration.Enrichers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch; 

namespace Logging.Configuration.Extensions
{
    public static class SerilogServices
    {
        public static IServiceCollection AddSerilogServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura la URI de Elasticsearch y el formato del índice desde tu archivo de configuración (appsettings.json)
            var elasticsearchUri = configuration["Elasticsearch:Uri"];
            var indexFormat = configuration["Elasticsearch:IndexFormat"] ?? "mi-indice-logs-{0:yyyy.MM}";

            services.AddLogging(builder =>
            {
                var serviceProvider = services.BuildServiceProvider();

                var loggerConfiguration = new LoggerConfiguration()
                    .Enrich.With(new PropertyFilterEnricher())
                    .Enrich.With(new DefaultLogTypeEnricherProvider(serviceProvider))
                    .Enrich.With(new TraceIdEnricher())
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Diagnostics", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore.Server.Kestrel", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .WriteTo.Async(a => a.Console(new ElasticsearchJsonFormatter(inlineFields: true,renderMessage: false, renderMessageTemplate: false)), bufferSize: 10)
                    .WriteTo.Async(a => a.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = indexFormat,
                        InlineFields = true,
                        FailureCallback = (e, exception) => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                           EmitEventFailureHandling.WriteToFailureSink |
                                           EmitEventFailureHandling.RaiseCallback,
                    }));

                var logger = loggerConfiguration.CreateLogger();

                builder.Services.AddSingleton<ILoggerFactory>(
                    provider => new SerilogLoggerFactory(logger, dispose: false)
                );
            });

            return services;
        }
    }
}
