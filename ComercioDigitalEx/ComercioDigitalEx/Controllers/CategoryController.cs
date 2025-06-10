using ComercioDigitalEx.Data;
using ComercioDigitalEx.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComercioDigitalEx.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
