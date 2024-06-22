using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;
using ErrorHandling.Interfaces;
using System.Collections.Generic; // Necesario para List<T>

namespace ErrorHandling.Abstracts
{
    public abstract class BaseExceptionHandler : IExceptionHandler
    {
        protected readonly ResponseApi _model;

        protected BaseExceptionHandler(ResponseApi model)
        {
            _model = model;
            // Asegurarse de que la lista de errores está inicializada
            if (_model.ListErrors == null)
            {
                _model.ListErrors = new List<BaseErrorModel>();
            }
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
            // Crear y configurar el nuevo error
            var error = new BaseErrorModel
            {
                code = context.Response.StatusCode.ToString(),
                data = "Parte del PaaS"
            };

            // Agregar el nuevo error a la lista
            _model.ListErrors.Add(error);
        }

        protected abstract void FillErrorAditional(Exception ex, HttpContext httpContext);
        protected abstract Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext);
    }
}