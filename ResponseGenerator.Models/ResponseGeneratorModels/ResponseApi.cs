using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ResponseGenerator.Models.ResponseGeneratorModels
{
	public class ResponseApi
	{
		[JsonPropertyName("meta")]
		public Meta Meta { get; set; } = new Meta();

		[JsonPropertyName("data")]
		public object Data { get; set; }

		[JsonPropertyName("errors")]
        public List<BaseErrorModel> ListErrors { get; set; } = new List<BaseErrorModel>();
    }
}