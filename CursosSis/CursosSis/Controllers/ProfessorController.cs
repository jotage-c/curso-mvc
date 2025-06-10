using CursosSis.Data;
using CursosSis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosSis.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProfessorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Professors.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Professor obj)
        {
            _db.Professors.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
