using Microsoft.AspNetCore.Mvc;
using GlobalExceptionHandler.Functional.Business;
using GlobalExceptionHandler.Functional.NotFound;
using GlobalExceptionHandler.Functional.Validation;
using GlobalExceptionHandler.Security.Authentication;
using GlobalExceptionHandler.Security.Authorization;
using GlobalExceptionHandler.Technical.Database;
using GlobalExceptionHandler.Technical.Network;
using GlobalExceptionHandler.Architectural.Configuration;
using GlobalExceptionHandler.Architectural.DependencyInjection;

namespace Api.Example.A.Controllers
{
    [ApiController]
    [Route("api/test-exceptions")]
    public class TestExceptionsController : ControllerBase
    {
        [HttpGet("business")]
        public IActionResult ThrowBusinessException()
        {
            throw new BusinessException("Error de negocio simulado.");
        }

        [HttpGet("not-found")]
        public IActionResult ThrowNotFoundException()
        {
            throw new NotFoundException("Recurso no encontrado simulado.");
        }

        [HttpGet("validation")]
        public IActionResult ThrowValidationException()
        {
            throw new ValidationException("Error de validación simulado.");
        }

        [HttpGet("authentication")]
        public IActionResult ThrowAuthenticationException()
        {
            throw new AuthenticationException("Error de autenticación simulado.");
        }

        [HttpGet("authorization")]
        public IActionResult ThrowAuthorizationException()
        {
            throw new AuthorizationException("Error de autorización simulado.");
        }

        [HttpGet("database")]
        public IActionResult ThrowDatabaseException()
        {
            throw new DatabaseException("Error de base de datos simulado.");
        }

        [HttpGet("io")]
        public IActionResult ThrowIOException()
        {
            throw new IOException("Error de E/S simulado.");
        }

        [HttpGet("network")]
        public IActionResult ThrowNetworkException()
        {
            throw new NetworkException("Error de red simulado.");
        }

        [HttpGet("configuration")]
        public IActionResult ThrowConfigurationException()
        {
            throw new ConfigurationException("Error de configuración simulado.");
        }

        [HttpGet("dependency-injection")]
        public IActionResult ThrowDependencyInjectionException()
        {
            throw new DependencyInjectionException("Error de inyección de dependencias simulado.");
        }
    }
}