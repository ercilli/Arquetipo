using Elasticsearch.Net;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System.Diagnostics;
using System.Threading;

namespace Logging.Configuration.Enrichers
{
    public class DefaultLogTypeEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultLogTypeEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            AddPropertyIfAbsent(logEvent, propertyFactory, "log_type", GetLogType());
            AddPropertyIfAbsent(logEvent, propertyFactory, "log_level", GetLogLevel(logEvent));
            AddPropertyIfAbsent(logEvent, propertyFactory, "logger_name", GetLoggerName(logEvent));
            AddPropertyIfAbsent(logEvent, propertyFactory, "thread_name", GetThreadName());
            AddPropertyIfAbsent(logEvent, propertyFactory, "http_request_address", GetHttpRequestAddress(httpContext));
            AddPropertyIfAbsent(logEvent, propertyFactory, "http_request_query_string", GetHttpRequestQueryString(httpContext));
            AddPropertyIfAbsent(logEvent, propertyFactory, "http_request_method", GetHttpRequestMethod(httpContext));
            AddPropertyIfAbsent(logEvent, propertyFactory, "http_request_path", GetHttpRequestPath(httpContext));
            AddPropertyIfAbsent(logEvent, propertyFactory, "http_request_remote_address", GetHttpRequestRemoteAddress(httpContext));
        }

        private string GetLoggerName(LogEvent logEvent)
        {
            return logEvent.Properties.ContainsKey("SourceContext") ? logEvent.Properties["SourceContext"].ToString() : "Unknown";
        }

        private string GetLogLevel(LogEvent logEvent)
        {
            return logEvent.Level.ToString();
        }

        private string GetLogType()
        {
            return "DEFAULT";
        }

        private string GetThreadName()
        {
            return Thread.CurrentThread.Name ?? Thread.CurrentThread.ManagedThreadId.ToString();
        }

        private string GetHttpRequestAddress(HttpContext httpContext)
        {
            return httpContext != null ? $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}" : "-";
        }

        private string GetHttpRequestQueryString(HttpContext httpContext)
        {
            var queryString = httpContext?.Request.QueryString.ToString();

            return string.IsNullOrEmpty(queryString) ? "-" : queryString;
        }

        private string GetHttpRequestMethod(HttpContext httpContext)
        {
            var requestMethod = httpContext?.Request.Method;

            return string.IsNullOrEmpty(requestMethod) ? "-" : requestMethod;
        }

        private string GetHttpRequestPath(HttpContext httpContext)
        {
            var requestPath = httpContext?.Request.Path.ToString();

            return string.IsNullOrEmpty(requestPath) ? "-" : requestPath;
        }

        private string GetHttpRequestRemoteAddress(HttpContext httpContext)
        {
            var remoteAddress = httpContext?.Connection.RemoteIpAddress?.ToString();

            return string.IsNullOrEmpty(remoteAddress) ? "-" : remoteAddress;
        }

        private void AddPropertyIfAbsent(LogEvent logEvent, ILogEventPropertyFactory propertyFactory, string propertyName, object value)
        {
            if (!logEvent.Properties.ContainsKey(propertyName))
            {
                LogEventProperty property = propertyFactory.CreateProperty(propertyName, value);
                logEvent.AddPropertyIfAbsent(property);
            }
        }
    }
}
