using ErrorHandling.Abstracts;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

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

