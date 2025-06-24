using ChamdosApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChamadosApp.Controllers
{
    public class CallController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CallController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var chamados = _context.Calls.Include(c => c.Client).ToList();
            return View(chamados);
        }
    }
}
