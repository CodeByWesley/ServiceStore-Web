using api.dtos;
using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicosController(ServicoService service) : ControllerBase
{
    private readonly ServicoService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ServicoDto>>> Get()
    {
        var servicos = await _service.ListarTodos();
        return Ok(servicos);
    }

    [HttpPost]
    public async Task<ActionResult<ServicoDto>> Post([FromBody] ServicoCreateDto dto)
    {     
        // Pegamos o resultado que o banco acabou de criar (que já vem com o ID)
        var resultado = await _service.Adicionar(dto);

        // Agora usamos o ID que veio do banco (via resultado)
        return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
    }
}
