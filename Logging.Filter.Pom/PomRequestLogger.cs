using Logging.Filter.Abstracts;
using Logging.Filter.Services;
using Logging.Models.LoggingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging.Filter.Pom;

public class PomRequestLogger : BaseRequestLogger
{
    private readonly RequestLoggingModel _model;

    public PomRequestLogger(RequestLoggingModel model, ILogger<BaseRequestLogger> logger)
             : base(model, logger)
    {
        _model = model;
    }

    protected override async Task LogAdditionalInfoAsync(HttpContext context)
    {
        var newModel = _model as PomRequestLoggingModel;
        newModel.CustomProperty = "esto es una prueba pom";
        await Task.CompletedTask; 
    }

    protected override async Task ModifyModelBeforeLogging(HttpContext context)
    {
        await Task.CompletedTask;
    }
}
