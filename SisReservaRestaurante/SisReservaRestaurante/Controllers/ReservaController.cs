using Microsoft.AspNetCore.Mvc;
using SisReservaRestaurante.Data;
using SisReservaRestaurante.Models;
using System;
using System.Diagnostics.Metrics;

namespace SisReservaRestaurante.Controllers
{
    public class ReservaController : Controller
    {
        private readonly AppDbContext _db;
        public ReservaController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var reservas = _db.Reservas.ToList();
            return View(reservas);
        }

        public IActionResult Create()
        {
            TempData["iddamesa"] = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Create(int iddamesa)
        {
            TempData["iddamesa"] = iddamesa;
            TempData["numeroDeLugares"] = _db.Mesas.Find(iddamesa)!.Lugares;
            return RedirectToAction("Create2");
        }

        public IActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create2(Reserva obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
        public IActionResult Delete(int id)
        {
            return View(_db.Reservas.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(Reserva obj)
        {
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
