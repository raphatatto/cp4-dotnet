using cp.Models;
using cp.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _service;
    public LivrosController(LivroService s) => _service = s;

    [HttpGet] public Task<List<Livro>> Get() => _service.GetAllAsync();
    [HttpGet("{id}")] public Task<Livro?> Get(string id) => _service.GetAsync(id);
    [HttpPost] public async Task<IActionResult> Post(Livro l) { await _service.CreateAsync(l); return CreatedAtAction(nameof(Get), new { id = l.Id }, l); }
    [HttpPut("{id}")] public async Task<IActionResult> Put(string id, Livro l) { await _service.UpdateAsync(id, l); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(string id) { await _service.DeleteAsync(id); return NoContent(); }
}
