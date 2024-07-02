using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

public class ResponseBuilder : IResponseBuilder
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ResponseApi _responseApi;

    public ResponseBuilder(IHttpContextAccessor httpContextAccessor, ResponseApi responseApi)
    {
        _httpContextAccessor = httpContextAccessor;
        _responseApi = responseApi;
    }

    public IResponseBuilder AddData(object data)
    {
        _responseApi.Data = data;
        return this;
    }

    public IResponseBuilder AddError(BaseErrorModel error)
    {
        _responseApi.ListErrors.Add(error);
        return this;
    }

    public ResponseApi BuildResponse()
    {
        _responseApi.Meta = new Meta
        {
            method = _httpContextAccessor.HttpContext.Request.Method,
            operation = _httpContextAccessor.HttpContext.Request.Path.ToString()
        };

        return _responseApi;
    }
}