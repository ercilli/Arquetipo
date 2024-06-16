using System;
namespace Logging.Models.LoggingModels
{
	public class InterceptorResponseLoggingModel : CommonLoggingModel
	{
        public string OutgoingHttpResponseStatusCode { get; set; }
        public string OutgoingHttpResponseStatusPhrase { get; set; }
        public string OutgoingHttpResponseBody { get; set; }
        public string OutgoingHttpResponseHeaders { get; set; }

        public InterceptorResponseLoggingModel()
		{
            OutgoingHttpResponseStatusCode = OutgoingHttpResponseStatusPhrase = OutgoingHttpResponseBody = OutgoingHttpResponseHeaders = "-";
		}

        public Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>
            {
                // Asumiendo que ya has añadido las propiedades de solicitud y respuesta entrante
                {"outgoing_http_response_status_code", OutgoingHttpResponseStatusCode},
                {"outgoing_http_response_status_phrase", OutgoingHttpResponseStatusPhrase},
                {"outgoing_http_response_body", OutgoingHttpResponseBody},
                {"outgoing_http_response_headers", OutgoingHttpResponseHeaders},
                {"log_type", LogType},
                {"thread_name", ThreadName},
                {"stack_trace", StackTrace},
                {"build_version", BuildVersion},
                {"build_parent_version", BuildParentVersion},
                {"id_channel", IdChannel},
                {"logging_tracking_id", LoggingTrackingId},
                {"jwt", Jwt},
                {"span_parent_id", SpanParentId},
                // Añade más propiedades aquí si es necesario
            };
            return dict;
        }
    }
}

