using Logging.Configuration.Enrichers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch; // Asegúrate de tener este using para acceder a ElasticsearchSinkOptions

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
                var loggerConfiguration = new LoggerConfiguration()
                    .Enrich.With(new PropertyFilterEnricher())
                    .Enrich.With(new DefaultLogTypeEnricher())
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Diagnostics", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
                    .WriteTo.Console(new JsonFormatter())
                    // Configura el sink de Elasticsearch
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = indexFormat,
                        InlineFields = true,
                        FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                           EmitEventFailureHandling.WriteToFailureSink |
                                           EmitEventFailureHandling.RaiseCallback,
                    });

                var logger = loggerConfiguration.CreateLogger();

                builder.Services.AddSingleton<ILoggerFactory>(
                    provider => new SerilogLoggerFactory(logger, dispose: false)
                );
            });

            return services;
        }
    }
}
