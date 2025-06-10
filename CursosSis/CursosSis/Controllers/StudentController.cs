using CursosSis.Data;
using CursosSis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosSis.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Students.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
