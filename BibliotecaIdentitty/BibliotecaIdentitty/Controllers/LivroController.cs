using BibliotecaIdentitty.Data;
using BibliotecaIdentitty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaIdentitty.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livros
        // Permitido para Admin E Colaborador
        [Authorize(Roles = "Admin,Colaborador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.ToListAsync());
        }

        // GET: Livros/Create
        // Permitido APENAS para Admin
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] Livro produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Livros/Edit/5
        // APENAS Admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            // ... (lógica padrão de edit)
            if (id == null) return NotFound();
            var produto = await _context.Livros.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] Livro produto)
        {
            // ... (lógica padrão de edit POST)
            if (id != produto.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) { /*...*/ throw; }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // As actions Delete (GET e POST) também devem ser protegidas com [Authorize(Roles = "Admin")]
    }
}
