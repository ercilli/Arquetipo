using System;
using System.Net;

namespace Logging.Models.LoggingModels
{
	public class ResponseLoggingModel : CommonLoggingModel
	{
        public string HttpDuration { get; set; }
        public string HttpResponseStatusCode { get; set; }
        public string HttpResponseStatusPhrase { get; set; }
        public string HttpResponseBody { get; set; }
        public string HttpResponseHeaders { get; set; }

        public ResponseLoggingModel()
		{
            HttpDuration = HttpResponseStatusCode = HttpResponseStatusPhrase = HttpResponseBody = HttpResponseHeaders = "-";
		}

        public override Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>
            {
                {"http_duration", HttpDuration},
                {"http_response_status_code", HttpResponseStatusCode},
                {"http_response_status_phrase", HttpResponseStatusPhrase},
                {"http_response_body", HttpResponseBody},
                {"http_response_headers", HttpResponseHeaders},
                {"log_type", LogType},
                {"thread_name", ThreadName},
                {"stack_trace", StackTrace},
                {"build_version", BuildVersion},
                {"build_parent_version", BuildParentVersion},
                {"id_channel", IdChannel},
                {"logging_tracking_id", LoggingTrackingId},
                {"jwt", Jwt},
                {"span_parent_id", SpanParentId},
            };
            return dict;
        }
    }
}

