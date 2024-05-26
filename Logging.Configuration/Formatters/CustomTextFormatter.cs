using System;
using System.IO;
using Serilog.Events;
using Serilog.Formatting;
using System.Text.Json;

namespace Logging.Configuration.Formatters
{
    public class CustomJsonFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            using (var stream = new MemoryStream())
            {
                using (var jsonWriter = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true }))
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WriteString("Timestamp", logEvent.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                    jsonWriter.WriteString("Level", logEvent.Level.ToString());
                    jsonWriter.WriteString("Message", logEvent.RenderMessage());
                    jsonWriter.WriteEndObject();
                }
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string jsonText = reader.ReadToEnd();
                    output.WriteLine(jsonText);
                }
            }
        }
    }
}
