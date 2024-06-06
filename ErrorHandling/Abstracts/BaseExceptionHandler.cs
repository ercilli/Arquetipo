using System.Net;
using System.Text.Json;
using ErrorHandling.Interfaces;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ErrorHandling.Abstracts
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        private readonly ResponseApi _model;

        protected BaseExceptionHandler(ResponseApi model)
        {
            _model = model;
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

            FillErrorAditional(exception, context);

            FillError(exception, context);

        }

        private void FillError(Exception ex, HttpContext context)
        {
            _model.Errors.code = context.Response.StatusCode.ToString();
            _model.Errors.data = "Parte del PaaS";
        }

        protected abstract void FillErrorAditional(Exception ex, HttpContext httpContext);

        protected abstract Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext);
    }
}

