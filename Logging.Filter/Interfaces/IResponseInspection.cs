﻿using System;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Interfaces
{
	public interface IResponseInspection
	{
        Task ResponseExtractAsync(string body);
    }
}

