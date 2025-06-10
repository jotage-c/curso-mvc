using ComercioDigitalEx.Data;
using ComercioDigitalEx.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComercioDigitalEx.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product obj)
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

            Product categoryFromDb = _db.Products.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.Products.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product categoryFromDb = _db.Products.Find(id);
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleting(int id)
        {
            Product categoryFromDb = _db.Products.Find(id);
            _db.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
