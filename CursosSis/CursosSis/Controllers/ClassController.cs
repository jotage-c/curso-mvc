using CursosSis.Data;
using CursosSis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosSis.Controllers
{
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClassController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Classes.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Class obj)
        {
            _db.Classes.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
