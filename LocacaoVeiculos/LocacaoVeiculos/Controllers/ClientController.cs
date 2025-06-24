using LocacaoVeiculos.Data;
using LocacaoVeiculos.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoVeiculos.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string search, int page = 1, int itensPerPage = 5)
        {
            var obj = _db.Clients
                .Where(p => string.IsNullOrEmpty(search) || p.ClientName.Contains(search))
                .Skip((page - 1) * itensPerPage)
                .Take(itensPerPage)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(obj.Count() / (double)itensPerPage);
            ViewBag.Search = search;
            ViewBag.Page = page;
            ViewBag.ItensPerPage = itensPerPage;

            return View(obj);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client c)
        {
            _db.Clients.Add(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var client = _db.Clients.Find(id);
            return View(client);
        }
        [HttpPost]
        public IActionResult Edit(Client c)
        {
            _db.Clients.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var client = _db.Clients.Find(id);
            return View(client);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var c = _db.Clients.Find(id);
            _db.Clients.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
