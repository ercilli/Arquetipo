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
            // Primero, registra la LoggerConfiguration
            services.AddLogging(provider =>
            {
                var serviceProvider = services.BuildServiceProvider();

                var elasticsearchUri = configuration["ELASTICSEARCH:URI"];
                var indexFormat = configuration["ELASTICSEARCH:INDEXFORMAT"] ?? "mi-indice-logs-{0:yyyy.MM}";

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
                    .WriteTo.Async(a => a.Console(
                        new ElasticsearchJsonFormatter(
                            inlineFields: true,
                            renderMessage: false,
                            renderMessageTemplate: false)),
                            bufferSize: 10);

                if (!string.IsNullOrEmpty(elasticsearchUri))
                {
                    loggerConfiguration.WriteTo.Async(a => a.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                    {
                        AutoRegisterTemplate = true,
                        InlineFields = true,
                        IndexFormat = indexFormat,
                    }));
                }

                var logger = loggerConfiguration.CreateLogger();

                provider.Services.AddSingleton<ILoggerFactory>(
                    provider => new SerilogLoggerFactory(logger, dispose: false)
                );

            });

            return services;
        }

        public static IServiceCollection AddSerilogServices(this IServiceCollection services, IConfiguration configuration, LoggerConfiguration loggerConfiguration)
        {
            // Primero, registra la LoggerConfiguration
            services.AddLogging(provider =>
            {
                var serviceProvider = services.BuildServiceProvider();

                var elasticsearchUri = configuration["ELASTICSEARCH:URI"];
                var indexFormat = configuration["ELASTICSEARCH:INDEXFORMAT"] ?? "mi-indice-logs-{0:yyyy.MM}";

                loggerConfiguration
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
                     .WriteTo.Async(a => a.Console(
                         new ElasticsearchJsonFormatter(
                             inlineFields: true,
                             renderMessage: false,
                             renderMessageTemplate: false)),
                             bufferSize: 10);

                if (!string.IsNullOrEmpty(elasticsearchUri))
                {
                    loggerConfiguration.WriteTo.Async(a => a.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                    {
                        AutoRegisterTemplate = true,
                        InlineFields = true,
                        IndexFormat = indexFormat,
                    }));
                }

                var logger = loggerConfiguration.CreateLogger();

                provider.Services.AddSingleton<ILoggerFactory>(
                    provider => new SerilogLoggerFactory(logger, dispose: false)
                );

            });

            return services;
        }

        public static LoggerConfiguration AddSerilogServicesBases(this IServiceCollection services, IConfiguration configuration, LoggerConfiguration loggerConfiguration)
        {

            var serviceProvider = services.BuildServiceProvider();

            var elasticsearchUri = configuration["ELASTICSEARCH:URI"];
            var indexFormat = configuration["ELASTICSEARCH:INDEXFORMAT"] ?? "mi-indice-logs-{0:yyyy.MM}";

            loggerConfiguration
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
                 .WriteTo.Async(a => a.Console(
                     new ElasticsearchJsonFormatter(
                         inlineFields: true,
                         renderMessage: false,
                         renderMessageTemplate: false)),
                         bufferSize: 10);

            if (!string.IsNullOrEmpty(elasticsearchUri))
            {
                loggerConfiguration.WriteTo.Async(a => a.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                {
                    AutoRegisterTemplate = true,
                    InlineFields = true,
                    IndexFormat = indexFormat,
                }));
            }



            return loggerConfiguration;
        }
    }
}

