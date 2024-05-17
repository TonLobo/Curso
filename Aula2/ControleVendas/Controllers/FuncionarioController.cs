using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NomesFuncionarios() 
        { 
            return View();
        }
    }
}
