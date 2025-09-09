using cp.Dtos;
using cp.Models;
using cp.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _service;
    public LivrosController(LivroService s) => _service = s;

    [HttpGet]
    public Task<List<Livro>> Get() => _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetById(string id)
    {
        var l = await _service.GetAsync(id);
        return l is null ? NotFound() : Ok(l);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LivroCreateDto dto)
    {
        var l = new Livro
        {
            Titulo = dto.Titulo,
            AnoPublicacao = dto.AnoPublicacao,
            Autor = new Autor { Nome = dto.Autor.Nome, Nacionalidade = dto.Autor.Nacionalidade }
        };

        await _service.CreateAsync(l);
        return CreatedAtAction(nameof(GetById), new { id = l.Id }, l);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] LivroUpdateDto dto)
    {
        var exists = await _service.GetAsync(id);
        if (exists is null) return NotFound();

        var l = new Livro
        {
            Id = id, // mantém o mesmo Id
            Titulo = dto.Titulo,
            AnoPublicacao = dto.AnoPublicacao,
            Autor = new Autor { Nome = dto.Autor.Nome, Nacionalidade = dto.Autor.Nacionalidade }
        };

        await _service.UpdateAsync(id, l);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
