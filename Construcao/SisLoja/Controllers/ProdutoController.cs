using Microsoft.AspNetCore.Mvc;
using SisLoja.Models;

namespace SisLoja.Controllers
{
    public class ProdutoController : Controller
    {
        private static List<Produto> _produtos = new List<Produto>()
            {
                new Produto { ProdutoId = 1, NomeProduto = "TV", Marca = "Samsung" },
                new Produto { ProdutoId = 2, NomeProduto = "home teacher", Marca = "Sony" },
                new Produto { ProdutoId = 3, NomeProduto = "Discman", Marca = "Aiwa" },
                new Produto { ProdutoId = 4, NomeProduto = "Karaokê", Marca = "Philco" }
            };
        public IActionResult Index()
        {
            return View(_produtos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produto produto)
        {

            if (ModelState.IsValid)
            {
                produto.ProdutoId = _produtos.Count > 0 ? _produtos.Max(c => c.ProdutoId) + 1 : 1;
                _produtos.Add(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }
    }
}
