using System.Diagnostics;
using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Funcionario()
        {
            return "Me chamo João e trabalho com TI";
        }
        //posso entrar por aqui colocando o nome da func depois da barra com Home

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
