using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Example.A.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IHttpClientFactory _client;

        public ValuesController(ILogger<ValuesController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Log information Example");

            return Ok("Servicio OK");
        }

        // GET: api/values
        [HttpGet("callApi")]
        public async Task<IActionResult> Get1()
        {
            var client = _client.CreateClient("Interceptor");
            var response = await client.GetAsync("https://rickandmortyapi.com/api");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return NotFound();
        }

        // GET: api/values
        [HttpGet("error")]
        public async Task<IActionResult> Get2()
        {
            throw new Exception("Se realiza una excepcion de prueba");
        }
    }
}

