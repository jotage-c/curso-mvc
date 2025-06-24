using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string busca, int pagina = 1, int itensPorPag = 5)
        {
            /*
            var objProductList = _db.Products.ToList();
            return View(objProductList);
            */

            var query = _db.Products
                .Where(p => string.IsNullOrEmpty(busca) || p.NameProduct.Contains(busca))
                .OrderBy(p => p.NameProduct) 
                .Skip((pagina - 1) * itensPorPag)
                .Take(itensPorPag)
                .ToList();

            ViewBag.TotalPaginas = (int)Math.Ceiling(pagina / (double)itensPorPag);
            ViewBag.PaginaAtual = pagina;
            ViewBag.Busca = busca;
            return View(query);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            _db.Products.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Product created successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
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
            TempData["warning"] = "Product edited successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product obj = _db.Products.Find(id);

            if (id == null)
            {
                return NotFound();
            }
            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["danger"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
