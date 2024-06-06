using ErrorHandling.Abstracts;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

namespace ErrorHandling.Services
{
    public class DefaultExceptionHandler : BaseExceptionHandler
    {
        private readonly ResponseApi _model;

        public DefaultExceptionHandler(ResponseApi model) : base(model)
        {
            _model = model;
        }

        protected override void FillErrorAditional(Exception ex, HttpContext httpContext)
        {
            
        }

        protected override async Task FillErrorAditionalAsync(Exception ex, HttpContext httpContext)
        {
            await Task.CompletedTask;
        }
    }
}

