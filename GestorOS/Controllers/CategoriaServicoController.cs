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

        public async Task<IActionResult> Delete(int id)
        {
            var categoriaServico = await _context.CategoriasServicos.FirstOrDefaultAsync(cs => cs.Id == id);
            return View(categoriaServico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaServico = await _context.CategoriasServicos
                .Include(cs => cs.Ordens)
                .FirstOrDefaultAsync(cs => cs.Id == id);

            if (categoriaServico != null)
            {
                if (categoriaServico.Ordens.Count > 0)
                {
                    TempData["Erro"] = "Não é possível excluir uma categoria que possui ordens de serviço associadas.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Remove(categoriaServico);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "categoria excluída com sucesso!";
            }

            return RedirectToAction(nameof(Index));

        }



    }
}
