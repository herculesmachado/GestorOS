using GestorOS.Data;
using GestorOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorOS.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        // construtor do controlador que recebe o contexto do banco de dados como parâmetro
        public ClienteController(ApplicationDbContext context)
        {
            // injeta o contexto do banco de dados no controlador
            _context = context;
        }

        // ação que retorna a view de listagem de clientes, com a possibilidade de filtrar por nome
        public async Task<IActionResult> Index(string? busca)
        {
            // cria uma consulta para buscar os clientes no banco de dados
            var query = _context.Clientes.AsQueryable();

            // verifica se a string de busca não é nula ou vazia
            if (!string.IsNullOrWhiteSpace(busca))
            {
                query = query.Where(c => c.Nome.Contains(busca));
            }

            
            ViewBag.Busca = busca;

            return View(await query.OrderBy(c => c.Nome).ToListAsync());
        }

        // ação que retorna a view de criação de cliente
        public IActionResult Create() => View();

        // ação que recebe os dados do cliente a ser criado e adiciona o registro no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            // verifica se o modelo é válido antes de adicionar o cliente ao banco de dados
            if (ModelState.IsValid)
            {
                
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente criado com sucesso!";
                // redireciona para a tela Index após criar o cliente
                return RedirectToAction(nameof(Index));
            }

            // se o modelo não for válido, retorna a view de criação com os erros de validação
            return View(cliente);
        }

        // ação que retorna a view de detalhes do cliente, buscando o cliente pelo id
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _context.Clientes.Include(c => c.Ordens).FirstOrDefaultAsync(c => c.Id == id);

            return cliente == null ? NotFound() : View(cliente);
        }

        // ação que retorna a view de edição de cliente, buscando o cliente pelo id
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            return cliente == null ? NotFound() : View(cliente);
        }

        // ação que recebe os dados do cliente editado e atualiza o registro no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();

            if(ModelState.IsValid)
            {
                _context.Update(cliente);
                cliente.DataCadastro = DateTime.SpecifyKind(cliente.DataCadastro, DateTimeKind.Utc);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }   



        public async Task<IActionResult> Delete(int id)
        {
            
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cliente = await _context.Clientes
                .Include(c => c.Ordens)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente != null)
            {
                if (cliente.Ordens.Count > 0)
                {
                    TempData["Erro"] = "Não é possível excluir um cliente que possui ordens de serviço associadas.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente excluído com sucesso!";
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
