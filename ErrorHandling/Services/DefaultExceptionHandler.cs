using ErrorHandling.Abstracts;
using ErrorHandling.Models.ErrorHandlingModels;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Services
{
    public class DefaultExceptionHandler : BaseExceptionHandler
    {
        private readonly BaseErrorModel _model;

        public DefaultExceptionHandler(BaseErrorModel model) : base(model)
        {
            _model = model;
        }

        protected override async Task<BaseErrorModel> AdditionalInfoAsync(Exception ex, HttpContext httpContext)
        {
            return _model;
        }
    }
}

