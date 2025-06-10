using CursosSis.Data;
using CursosSis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosSis.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Courses.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course obj)
        {
            _db.Courses.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
