using System;
namespace ResponseGenerator.Models.ResponseGeneratorModels
{
	public class ResponseApi
	{
		public Meta Meta { get; set; } = new Meta();
		public string Data { get; set; }
		public BaseErrorModel Errors { get; set; } = new BaseErrorModel();
	}
}

