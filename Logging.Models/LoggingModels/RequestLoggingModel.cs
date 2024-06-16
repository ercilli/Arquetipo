using System;
namespace Logging.Models.LoggingModels
{
    public class RequestLoggingModel : CommonLoggingModel
    {

        public string HttpRequestBody { get; set; } 
        public string HttpRequestHeader { get; set; }
        public string HttpDuration { get; set; }
        public string PruebaPiloto { get; set; }

        public RequestLoggingModel()
        {
            HttpRequestBody = HttpRequestHeader = HttpDuration = PruebaPiloto = "-";
        }

        public override Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>
            {
                {"http_request_method", HttpRequestMethod},
                {"http_request_path", HttpRequestPath},
                {"http_request_address", HttpRequestAddress},
                {"http_request_query_string", HttpRequestQueryString},
                {"http_request_remote_address", HttpRequestRemoteAddress},
                {"http_request_body", HttpRequestBody},
                {"http_request_header", HttpRequestHeader},
                {"http_duration", HttpDuration},
                {"log_type", LogType},
                {"thread_name", ThreadName},
                {"stack_trace", StackTrace},
                {"build_version", BuildVersion},
                {"build_parent_version", BuildParentVersion},
                {"id_channel", IdChannel},
                {"logging_tracking_id", LoggingTrackingId},
                {"jwt", Jwt},
                {"span_parent_id", SpanParentId},
                {"pruebapiloto", PruebaPiloto},
            };
            return dict;
        }
    }
}

