using System.Net;
using System.Text.Json;
using ErrorHandling.Interfaces;
using ErrorHandling.Models.ErrorHandlingModels;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Abstracts
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        private readonly BaseErrorModel _model;

        protected BaseExceptionHandler(BaseErrorModel model)
        {
            _model = model;
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Modificar según la lógica

            FillError(exception, context);

            var errorModel = await AdditionalInfoAsync(exception, context);

            var response = JsonSerializer.Serialize(errorModel);

            await context.Response.WriteAsync(response);
        }

        private void FillError(Exception ex, HttpContext context)
        {
            _model.status_code = context.Response.StatusCode.ToString();
            _model.code = "paas-0123";
        }

        protected abstract Task<BaseErrorModel> AdditionalInfoAsync(Exception ex, HttpContext httpContext);
    }
}

