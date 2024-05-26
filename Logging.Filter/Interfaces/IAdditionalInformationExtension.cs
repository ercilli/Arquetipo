using System;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Interfaces
{
	public interface IAdditionalInformationExtension
	{
        Task LogAdditionalInfoAsync(HttpContext context);
        Task ModifyModelBeforeLogging(HttpContext context);
    }
}

