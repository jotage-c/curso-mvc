using ExercicioManipulacaoDb.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioManipulacaoDb.Controllers
{
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SongController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objSongList = _db.Songs.ToList();
            return View(objSongList);
        }
    }
}
