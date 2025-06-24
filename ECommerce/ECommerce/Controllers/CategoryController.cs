using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.Metrics;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string busca, int pagina = 1, int tamanhoDaPagina = 2)
        {
            //var objCategoryList = _db.Categories.ToList();
            //return View(objCategoryList);

            var objCategoryList = _db.Categories
                .Where(c => string.IsNullOrEmpty(busca) || c.Name.Contains(busca))
                .OrderBy(c => c.Name)
                .Skip((pagina - 1) * tamanhoDaPagina)
                .Take(tamanhoDaPagina)
                .ToList();

            ViewBag.TotalPaginas = (int)Math.Ceiling(pagina / (double)tamanhoDaPagina);
            ViewBag.PaginaAtual = pagina;
            ViewBag.Busca = busca;
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name must not match the Display Order.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View();
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
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["warning"] = "Category edited successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
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
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category obj = _db.Categories.Find(id);

            if (id == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["danger"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
