using cp.Models;
using cp.Service;
using Microsoft.AspNetCore.Mvc;

namespace cp.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroService _service;
        public LivroController(LivroService service) => _service = service;

        // LISTA
        public async Task<IActionResult> Index() =>
            View(await _service.GetAllAsync());

        // DETALHES
        public async Task<IActionResult> Details(string id)
        {
            var livro = await _service.GetAsync(id);
            if (livro is null) return NotFound();
            return View(livro);
        }

        // CREATE
        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (!ModelState.IsValid) return View(livro);
            await _service.CreateAsync(livro);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit(string id)
        {
            var livro = await _service.GetAsync(id);
            if (livro is null) return NotFound();
            return View(livro);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Livro livro)
        {
            if (!ModelState.IsValid) return View(livro);
            await _service.UpdateAsync(id, livro);
            return RedirectToAction(nameof(Index));
        }

        // DELETE (confirmação)
        public async Task<IActionResult> Delete(string id)
        {
            var livro = await _service.GetAsync(id);
            if (livro is null) return NotFound();
            return View(livro);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
