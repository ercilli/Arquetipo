using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ResponseGenerator.Models.ResponseGeneratorModels;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IResponseBuilder _responseBuilder;

    public ExampleController(IResponseBuilder responseBuilder)
    {
        _responseBuilder = responseBuilder;
    }

    [HttpGet("data-and-errors")]
    public IActionResult GetDataAndErrors()
    {
        var error = new BaseErrorModelBuilder()
            .WithCode("404")
            .WithReason("Not Found")
            .WithStatusCode("404")
            .WithDetail("The requested resource was not found.")
            .WithMessage("Resource not found")
            .Build();

        var response = _responseBuilder
            .AddData("Here is your data")
            .AddError(error)
            .BuildResponse();

        return Ok(response);
    }

    [HttpGet("only-data")]
    public IActionResult GetOnlyData()
    {
        var response = _responseBuilder
            .AddData("Only data, no errors here")
            .BuildResponse();

        return Ok(response);
    }

    [HttpGet("only-errors")]
    public IActionResult GetOnlyErrors()
    {
        var error = new BaseErrorModelBuilder()
            .WithCode("500")
            .WithReason("Internal Server Error")
            .WithStatusCode("500")
            .WithDetail("An unexpected error occurred.")
            .WithMessage("Internal error")
            .Build();

        var response = _responseBuilder
            .AddError(error)
            .BuildResponse();

        return Ok(response);
    }
}