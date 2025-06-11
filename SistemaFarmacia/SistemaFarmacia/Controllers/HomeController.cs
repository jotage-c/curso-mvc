using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.Data;
using SistemaFarmacia.Models;

namespace SistemaFarmacia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var obj = _db.Companies.ToList();
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Company obj)
        {
            _db.Companies.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
