using Microsoft.AspNetCore.Mvc;

namespace ComercioDigitalEx.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
