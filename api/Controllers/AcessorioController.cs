using api.dtos;
using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoriosController(AcessorioService service) : ControllerBase
    {
        private readonly AcessorioService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<AcessorioDto>>> Get()
        {
            var servicos = await _service.ListarTodos();
            return Ok(servicos);
        }

        [HttpPost]
        public async Task<ActionResult<AcessorioDto>> Post([FromBody] AcessorioCreateDto dto)
        {
            var resultado = await _service.Adicionar(dto);
            return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
        }
    }
}
