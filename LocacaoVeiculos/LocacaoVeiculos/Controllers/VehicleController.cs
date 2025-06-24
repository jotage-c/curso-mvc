using LocacaoVeiculos.Data;
using LocacaoVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculos.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VehicleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string search, int page = 1, int itensPerPage = 5)
        {
            var obj = _db.Vehicles
                .Where(p => string.IsNullOrEmpty(search) || p.VehicleModel.Contains(search))
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
        public IActionResult Create(Vehicle c)
        {
            _db.Vehicles.Add(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _db.Vehicles.Find(id);
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle c)
        {
            _db.Vehicles.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var vehicle = _db.Vehicles.Find(id);
            return View(vehicle);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var c = _db.Vehicles.Find(id);
            _db.Vehicles.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Rent(int id)
        {
            var vehicle = _db.Vehicles.Find(id);
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Rent(Vehicle c)
        {
            _db.Vehicles.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
