using LocadoraVeiculosApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApp.Controllers
{
    public class RentsController : Controller
    {
        private readonly AppDbContext _context;
        public RentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rents = _context.Rents.Include(l => l.Cliente).Include(l => l.Veiculo).ToList();
            return View(rents);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewBag.Clients = _context.Clients
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                })
                .ToList();
            ViewBag.Vehicles = _context.Vehicles
                .Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = $"{v.Marca} {v.Modelo}) - R$ {v.ValorDiaria:F2}/dia"
                }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Rent locacao)
        {
            if (ModelState.IsValid)
            {
                var veiculo = _context.Vehicles.First(v => v.Id == locacao.VeiculoId);

                locacao.Veiculo = veiculo;
                locacao.CalcularValor();
                veiculo.EstaLocado = true;

                _context.Rents.Add(locacao);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_context.Clients, "Id", "Nome", locacao.ClienteId);
            ViewBag.Veiculos = new SelectList(_context.Vehicles.Where(v => !v.EstaLocado), "Id", "Modelo", locacao.VeiculoId);
            return View(locacao);
        }


        public IActionResult Devolver(int id)
        {
            var locacao = _context.Rents
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                .FirstOrDefault(l => l.Id == id);

            if (locacao == null)
                return NotFound();

            return View(locacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DevolverConfirmado(int id)
        {
            var locacao = _context.Rents
                .Include(l => l.Veiculo)
                .FirstOrDefault(l => l.Id == id);

            if (locacao == null)
                return NotFound();

            locacao.DataDevolvida = DateTime.Now;
            locacao.CalcularValor();

            if (locacao.Veiculo != null)
            {
                locacao.Veiculo.EstaLocado = false;
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Relatorio()
        {
            ViewBag.Clientes = _context.Clients
             .Select(c => new SelectListItem
             {
                 Value = c.Id.ToString(),
                 Text = c.Nome
             }).ToList();

            ViewBag.Veiculos = _context.Vehicles
                .Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = v.Modelo
                }).ToList();

            return View();
        }

        [HttpGet]
        public IActionResult BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim, int? clienteId, int? veiculoId)
        {
            // Inicia a query base com Include para Cliente e Veiculo
            var query = _context.Rents
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                .Where(l => l.DataRetirada >= dataInicio && l.DataRetirada <= dataFim);

            // Aplica filtro por cliente, se fornecido
            if (clienteId.HasValue)
                query = query.Where(l => l.ClienteId == clienteId.Value);

            // Aplica filtro por veículo, se fornecido
            if (veiculoId.HasValue)
                query = query.Where(l => l.VeiculoId == veiculoId.Value);

            // Executa a consulta
            var locacoes = query.ToList();

            // Projeta os dados em uma estrutura anônima para o front-end
            var lista = locacoes.Select(l => new {
                cliente = l.Cliente?.Nome ?? "N/A",
                veiculo = l.Veiculo != null ? $"{l.Veiculo.Marca} {l.Veiculo.Modelo}" : "N/A",
                dataRetirada = l.DataRetirada,
                dataDevolucaoPrevista = l.DataDevolucaoPrevista,
                dataDevolvida = l.DataDevolvida,
                valorTotal = l.ValorTotal,
                valorMulta = l.ValorMulta
            }).ToList();

            // Cria um resumo com totais para exibição
            var resumo = new
            {
                totalLocacoes = locacoes.Count,
                valorTotal = locacoes.Sum(l => l.ValorTotal),
                multaTotal = locacoes.Sum(l => l.ValorMulta)
            };

            // Retorna os dados em formato JSON
            return Json(new { locacoes = lista, resumo });
        }

    }
}
