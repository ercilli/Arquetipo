using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;

namespace Logging.Models.LoggingModels
{
	public class CommonLoggingModel
	{
        public string LogType { get; set; }
        public string ThreadName { get; set; }
        public string StackTrace { get; set; }
        public string BuildVersion { get; set; }
        public string BuildParentVersion { get; set; }
        public string IdChannel { get; set; }
        public string LoggingTrackingId { get; set; }
        public string Jwt { get; set; }
        public string TraceId { get; set; }
        public string SpanId { get; set; }
        public string SpanParentId { get; set; }
        public string HttpRequestAddress { get; set; }
        public string HttpRequestQueryString { get; set; }
        public string HttpRequestMethod { get; set; }
        public string HttpRequestPath { get; set; }
        public string HttpRequestRemoteAddress { get; set; }

        public CommonLoggingModel()
        {
            LogType = ThreadName = StackTrace = BuildVersion = BuildParentVersion = IdChannel = LoggingTrackingId = Jwt = TraceId = SpanId = SpanParentId = HttpRequestAddress = HttpRequestQueryString = HttpRequestMethod = HttpRequestPath = HttpRequestRemoteAddress = "-";
            Console.WriteLine("Instancio CommonLoggingModel");
        }

        public virtual Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>
            {
                {"http_request_method", HttpRequestMethod},
                {"http_request_path", HttpRequestPath},
                {"http_request_address", HttpRequestAddress},
                {"http_request_query_string", HttpRequestQueryString},
                {"http_request_remote_address", HttpRequestRemoteAddress},
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
            };

            return dict;
        }
    }
}

