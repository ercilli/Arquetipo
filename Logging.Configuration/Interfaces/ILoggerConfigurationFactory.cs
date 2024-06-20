using System;
using Serilog;

namespace Logging.Configuration.Interfaces
{
	public interface ILoggerConfigurationFactory
	{
        LoggerConfiguration Create();
    }
}

