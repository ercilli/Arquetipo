using Logging.Models.LoggingModels;

namespace Logging.Filter.Pom
{
    public class PomRequestLoggingModel : RequestLoggingModel
    {
        public string CustomProperty { get; set; }

        public PomRequestLoggingModel()
        {
            CustomProperty = "Default";
        }

        public override Dictionary<string, object> ToDictionary()
        {
            var dict = base.ToDictionary();
            dict.Add("Pom", CustomProperty);
            return dict;
        }
    }
}