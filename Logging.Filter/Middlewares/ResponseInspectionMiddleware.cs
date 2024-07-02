using Logging.Filter.Interfaces;
using Microsoft.AspNetCore.Http;

public class ResponseInspectionMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseInspectionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IResponseInspection _inspect)
    {
        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);

                var body = await new StreamReader(context.Response.Body).ReadToEndAsync();

                await _inspect.ResponseExtractAsync(body);

                context.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBody.CopyToAsync(originalBodyStream);

            }
            catch (Exception ex)
            {
                // Manejo de excepciones locales si es necesario
                context.Response.Body = originalBodyStream;

                throw; // Re-lanzar la excepción para que otros middlewares la manejen
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
