using ExercicioManipulacaoDb.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioManipulacaoDb.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objGameList = _db.Games.ToList();
            return View(objGameList);
        }
    }
}
