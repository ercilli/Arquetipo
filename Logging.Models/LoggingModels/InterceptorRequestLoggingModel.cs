using System;
namespace Logging.Models.LoggingModels
{
    public class InterceptorRequestLoggingModel : CommonLoggingModel
    {
        public string OutgoingHttpDuration { get; set; }
        public string OutgoingHttpRequestAddress { get; set; }
        public string OutgoingHttpRequestQueryString { get; set; }
        public string OutgoingHttpRequestMethod { get; set; }
        public string OutgoingHttpRequestPath { get; set; }
        public string OutgoingHttpRequestRemoteAddress { get; set; }
        public string OutgoingHttpRequestBody { get; set; }
        public string OutgoingHttpRequestHeaders { get; set; }

        public InterceptorRequestLoggingModel()
        {
            OutgoingHttpDuration = OutgoingHttpRequestAddress = OutgoingHttpRequestQueryString = OutgoingHttpRequestMethod = OutgoingHttpRequestPath = OutgoingHttpRequestRemoteAddress = OutgoingHttpRequestBody = OutgoingHttpRequestHeaders = "-";
        }

        public Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>
            {
                // Asumiendo que ya has añadido las propiedades de solicitud y respuesta entrante y saliente
                {"outgoing_http_duration", OutgoingHttpDuration},
                {"outgoing_http_request_address", OutgoingHttpRequestAddress},
                {"outgoing_http_request_query_string", OutgoingHttpRequestQueryString},
                {"outgoing_http_request_method", OutgoingHttpRequestMethod},
                {"outgoing_http_request_path", OutgoingHttpRequestPath},
                {"outgoing_http_request_remote_address", OutgoingHttpRequestRemoteAddress},
                {"outgoing_http_request_body", OutgoingHttpRequestBody},
                {"outgoing_http_request_headers", OutgoingHttpRequestHeaders},
                {"log_type", LogType},
                {"thread_name", ThreadName},
                {"stack_trace", StackTrace},
                {"build_version", BuildVersion},
                {"build_parent_version", BuildParentVersion},
                {"id_channel", IdChannel},
                {"logging_tracking_id", LoggingTrackingId},
                {"jwt", Jwt},
                {"trace_id", TraceId},
                {"span_id", SpanId},
                {"span_parent_id", SpanParentId},
                // Añade más propiedades aquí si es necesario
            };
            return dict;
        }
    }
}

