using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Logging.Configuration.Pom;

public static class AddLoggingPom
{
    public static LoggerConfiguration AddSerilogServicesPom()
    {
        return new LoggerConfiguration().Enrich.With(new EnricherPom());
    }
}
