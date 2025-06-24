using LocadoraVeiculosApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApp.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly AppDbContext _context;
        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Vehicles.ToList();
            return View(clients);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Vehicle v)
        {
            _context.Vehicles.Add(v);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cliente = _context.Vehicles.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle v)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Update(v);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v);
        }

        // GET: Vehicles/Delete/5
        public IActionResult Delete(int id)
        {
            var v = _context.Vehicles.Find(id);
            if (v == null) return NotFound();
            return View(v);
        }

        // POST: Vehicles/Delete/5
        [HttpPost]
        public IActionResult Delete(Client cliente)
        {
            var clienteBanco = _context.Vehicles.Find(cliente.Id);
            if (clienteBanco == null) return NotFound();

            _context.Vehicles.Remove(clienteBanco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
