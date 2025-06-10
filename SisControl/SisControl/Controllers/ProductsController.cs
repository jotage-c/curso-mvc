using Microsoft.AspNetCore.Mvc;

namespace SisControl.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
