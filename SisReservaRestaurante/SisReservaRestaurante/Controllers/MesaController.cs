using Microsoft.AspNetCore.Mvc;
using SisReservaRestaurante.Data;
using System;

namespace SisReservaRestaurante.Controllers
{
    public class MesaController : Controller
    {
        private readonly AppDbContext _db;
        public MesaController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var mesas = _db.Mesas.ToList();
            return View(mesas);
        }
    }
}
