using GestorOS.Data;
using GestorOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorOS.Controllers
{
    public class CategoriaServicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaServicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriasServicos.OrderBy(c => c.Nome).ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaServicos categoriaServicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaServicos);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Categoria de serviço criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(categoriaServicos);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriaServicos = await _context.CategoriasServicos.FindAsync(id);

            return categoriaServicos == null ? NotFound() : View(categoriaServicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaServicos categoriaServicos)
        {
            if (id != categoriaServicos.Id) return NotFound();

            if(ModelState.IsValid)
            {
                _context.Update(categoriaServicos);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Categoria atualizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            
            return View(categoriaServicos);
            
        }
    }
}
