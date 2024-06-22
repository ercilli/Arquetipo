using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;
using ErrorHandling.Interfaces;
using GlobalExceptionHandler;
using GlobalExceptionHandler.Technical.Database;
using GlobalExceptionHandler.Functional.Business;

namespace ErrorHandling.Abstracts
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        protected readonly ResponseApi _model;

        protected BaseExceptionHandler(ResponseApi model)
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
            var errors = new List<BaseErrorModel>();
            var currentException = ex;

            while (currentException != null)
            {
                // Llamada a CategorizeAndHandleExceptionAsync para determinar el tipo de excepción
                CategorizeAndHandleException(currentException, context);

                currentException = currentException.InnerException;
            }

            errors.Reverse();

            foreach (var error in errors)
            {
                _model.ListErrors.Add(error);
            }
        }

        protected void CategorizeAndHandleException(Exception exception, HttpContext context)
        {
            context.Response.ContentType = "application/json";

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
            var error = new BaseErrorModel
            {
                code = context.Response.StatusCode.ToString(),
                detail = exception.Message ?? defaultMessage,
                trace = FilterStackTrace(exception.StackTrace),
                // Agregar más campos según sea necesario
            };

            _model.ListErrors.Add(error);
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