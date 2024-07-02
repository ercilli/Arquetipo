namespace ResponseGenerator.Models.ResponseGeneratorModels
{
    public class BaseErrorModelBuilder
    {
        private readonly BaseErrorModel _errorModel = new BaseErrorModel();

        public BaseErrorModelBuilder WithCode(string code)
        {
            _errorModel.code = code;
            return this;
        }

        // Métodos similares para cada propiedad...
        public BaseErrorModelBuilder WithReason(string reason)
        {
            _errorModel.reason = reason;
            return this;
        }

        public BaseErrorModelBuilder WithStatusCode(string statusCode)
        {
            _errorModel.status_code = statusCode;
            return this;
        }

        public BaseErrorModelBuilder WithDetail(string detail)
        {
            _errorModel.detail = detail;
            return this;
        }

        public BaseErrorModelBuilder WithMessage(string message)
        {
            _errorModel.message = message;
            return this;
        }

        // Continúa con el resto de las propiedades...

        public BaseErrorModelBuilder WithCustomErrorType(string customErrorType)
        {
            _errorModel.custom_error_type = customErrorType;
            return this;
        }

        public BaseErrorModelBuilder WithExtensions(object extensions)
        {
            _errorModel.extensions = extensions;
            return this;
        }

        public BaseErrorModelBuilder WithTrace(string trace)
        {
            _errorModel.trace = trace;
            return this;
        }

        public BaseErrorModel Build()
        {
            return _errorModel;
        }
    }
}