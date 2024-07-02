using ResponseGenerator.Models.ResponseGeneratorModels;

public interface IResponseBuilder
{
    IResponseBuilder AddData(object data);
    IResponseBuilder AddError(BaseErrorModel error);
    ResponseApi BuildResponse();
}
