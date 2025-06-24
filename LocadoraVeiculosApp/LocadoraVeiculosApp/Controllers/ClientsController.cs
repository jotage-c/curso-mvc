using LocadoraVeiculosApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraVeiculosApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext _context;
        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cliente = _context.Clients.Find(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Edit(Client cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clients/Delete/5
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clients.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public IActionResult Delete(Client cliente)
        {
            var clienteBanco = _context.Clients.Find(cliente.Id);
            if (clienteBanco == null) return NotFound();

            _context.Clients.Remove(clienteBanco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
