﻿using System;
using Microsoft.AspNetCore.Http;

namespace Logging.Filter.Interfaces
{
    public interface IResponseLogger
    {
        Task LogResponseAsync();
    }
}

