using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NomesProdutos() 
        { 
            return View(); 
        }
    }
}
