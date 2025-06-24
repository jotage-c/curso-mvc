using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace docasp.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Welcome(string name, int numTimes)
        {
            ViewBag.Name = name;
            ViewBag.NumTimes = numTimes;
            return View();
        }
    }
}
