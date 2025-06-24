using ChamadosApp.Models;
using ChamdosApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string busca, int pagina = 1, int tamanhoPagina = 5)
        {
            var query = _context.Clients.AsQueryable();

            if (!string.IsNullOrEmpty(busca))
                query = query.Where(c => c.NameClient.Contains(busca));

            int totalRegistros = query.Count();
            var clientes = query
                .OrderBy(c => c.NameClient)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            ViewBag.TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
            ViewBag.PaginaAtual = pagina;
            ViewBag.Busca = busca;

            return View(clientes);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Client obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _context.Clients.Update(obj);
            _context.SaveChanges();
            TempData["warning"] = "Client edited successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Client categoryFromDb = _context.Clients.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Client obj = _context.Clients.Find(id);

            if (id == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(obj);
            _context.SaveChanges();
            TempData["danger"] = "Client deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
