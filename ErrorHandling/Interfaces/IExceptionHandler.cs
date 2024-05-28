
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Interfaces
{
    public interface IExceptionHandler
    {
        Task HandleExceptionAsync(Exception exception, HttpContext context);
    }
}

