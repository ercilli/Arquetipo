using Microsoft.AspNetCore.Mvc;

namespace Api.Example.A.Controllers
{
    [ApiController]
    [Route("api/status-test")]
    public class StatusTestController : ControllerBase
    {
        [HttpGet("ok")]
        public IActionResult ReturnOk()
        {
            return Ok("Respuesta OK con código 200.");
        }

        [HttpGet("created")]
        public IActionResult ReturnCreated()
        {
            // Simula la creación de un recurso con una URI ficticia
            return Created("http://example.com/resource/1", new { message = "Recurso creado con código 201." });
        }

        [HttpGet("no-content")]
        public IActionResult ReturnNoContent()
        {
            return NoContent();
        }

        [HttpGet("bad-request")]
        public IActionResult ReturnBadRequest()
        {
            return BadRequest("Respuesta Bad Request con código 400.");
        }

        [HttpGet("unauthorized")]
        public IActionResult ReturnUnauthorized()
        {
            return Unauthorized("No autorizado con código 401.");
        }

        [HttpGet("forbidden")]
        public IActionResult ReturnForbidden()
        {
            return Forbid("Acceso prohibido con código 403.");
        }

        [HttpGet("not-found")]
        public IActionResult ReturnNotFound()
        {
            return NotFound("Recurso no encontrado con código 404.");
        }

        [HttpGet("internal-server-error")]
        public IActionResult ReturnInternalServerError()
        {
            return StatusCode(500, "Error interno del servidor con código 500.");
        }

        [HttpGet("not-implemented")]
        public IActionResult ReturnNotImplemented()
        {
            return StatusCode(501, "No implementado con código 501.");
        }

        [HttpGet("bad-gateway")]
        public IActionResult ReturnBadGateway()
        {
            return StatusCode(502, "Bad Gateway con código 502.");
        }

        [HttpGet("service-unavailable")]
        public IActionResult ReturnServiceUnavailable()
        {
            return StatusCode(503, "Servicio no disponible con código 503.");
        }

        [HttpGet("gateway-timeout")]
        public IActionResult ReturnGatewayTimeout()
        {
            return StatusCode(504, "Gateway Timeout con código 504.");
        }
    }
}