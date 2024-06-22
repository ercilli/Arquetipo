using System;
namespace ResponseGenerator.Models.ResponseGeneratorModels
{
	public class ResponseApi
	{
		public Meta Meta { get; set; } = new Meta();
		public string Data { get; set; }
		public List<BaseErrorModel> ListErrors { get; set; } = new List<BaseErrorModel>();
	}
}

