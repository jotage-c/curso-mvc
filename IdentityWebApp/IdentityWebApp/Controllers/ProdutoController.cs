using Microsoft.AspNetCore.Mvc;

namespace IdentityWebApp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
