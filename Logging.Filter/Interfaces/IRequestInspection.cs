using System;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Interfaces
{
	public interface IRequestInspection
	{
		Task RequestExtractAsync(HttpContext context);
	}
}

