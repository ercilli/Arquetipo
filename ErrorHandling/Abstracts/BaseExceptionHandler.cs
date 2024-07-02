using System.Net;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;
using ErrorHandling.Interfaces;
using GlobalExceptionHandler.Technical.Database;
using GlobalExceptionHandler.Functional.Business;
using Microsoft.AspNetCore.WebUtilities;

namespace ErrorHandling.Abstracts
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        protected readonly IResponseBuilder _model;

        protected BaseExceptionHandler(IResponseBuilder model)
        {
            _model = model;
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            FillError(exception, context);
            FillErrorAditional(exception, context); // Asegúrate de que esta implementación exista y sea relevante.
        }

        private void FillError(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";

            while (ex != null)
            {
                // Llamada a CategorizeAndHandleExceptionAsync para determinar el tipo de excepción
                CategorizeAndHandleException(ex, context);

                ex = ex.InnerException;
            }

        }

        protected void CategorizeAndHandleException(Exception exception, HttpContext context)
        {
            switch (exception)
            {
                case DatabaseException dbException:
                    HandleDatabaseException(dbException, context);
                    break;
                case BusinessException businessException:
                    HandleBusinessException(businessException, context);
                    break;
                default:
                    HandleUnknownException(exception, context);
                    break;
            }
        }

        private void HandleDatabaseException(DatabaseException exception, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            AddErrorToModel(exception, context, "Database error occurred.");
        }

        private void HandleBusinessException(BusinessException exception, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            AddErrorToModel(exception, context, "Business rule violation.");
        }

        private void HandleUnknownException(Exception exception, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            AddErrorToModel(exception, context, "Unhandled error occurred.");
        }

        private void AddErrorToModel(Exception exception, HttpContext context, string defaultMessage)
        {
            var error = new BaseErrorModelBuilder()
                        .WithStatusCode(context.Response.StatusCode.ToString())
                        .WithCode(ReasonPhrases.GetReasonPhrase(context.Response.StatusCode))
                        .WithDetail(exception.Message ?? defaultMessage)
                        .WithTrace(FilterStackTrace(exception.StackTrace))
                        .Build();

            _model.AddError(error);
        }

        private string FilterStackTrace(string stackTrace)
        {
            var lines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var filteredLines = lines.Take(5); // Tomar solo las primeras 5 líneas como ejemplo
            return string.Join(Environment.NewLine, filteredLines);
        }

        protected abstract void FillErrorAditional(Exception ex, HttpContext httpContext);
        protected abstract Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext);
    }
}