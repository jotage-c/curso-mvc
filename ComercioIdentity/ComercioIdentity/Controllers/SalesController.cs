using ComercioIdentity.Data;
using ComercioIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComercioIdentity.Controllers
{
    [Authorize(Roles = "Funcionário,Admin")]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Sales
        public async Task<IActionResult> Index()
        {
            var sales = await _context.Sales
                .Include(s => s.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();

            return View(sales);
        }

        // GET: /Sales/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        // POST: /Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<SaleItem> items)
        {
            if (items == null || !items.Any())
            {
                ModelState.AddModelError("", "Você deve selecionar ao menos um produto.");
                ViewBag.Products = await _context.Products.ToListAsync();
                return View();
            }

            var sale = new Sale
            {
                Date = DateTime.Now,
                Items = new List<SaleItem>()
            };

            foreach (var item in items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    ModelState.AddModelError("", $"Estoque insuficiente para o produto: {product?.Name ?? "Desconhecido"}");
                    ViewBag.Products = await _context.Products.ToListAsync();
                    return View();
                }

                // Baixa de estoque
                product.Stock -= item.Quantity;

                sale.Items.Add(new SaleItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });
            }

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            TempData["error"] = "Venda registrada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Sales/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null) return NotFound();

            return View(sale);
        }
    }
}
