using Microsoft.AspNetCore.Mvc;
using Blogs.Data;
using Blogs.Models;


namespace Blogs.Controllers;

public class PostController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public PostController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult Index()
    {
        var posts = _context.Posts.ToList();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, IFormFile imagem)
    {
        if (imagem != null && imagem.Length > 0)
        {
            string pasta = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
            string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                imagem.CopyTo(stream);
            }

            post.PostImageUrl = "/uploads/" + nomeArquivo;
        }

        post.PostCreationDate = DateTime.Now;
        _context.Posts.Add(post);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
