using Microsoft.AspNetCore.Mvc;

namespace MVComTopLevel.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Saudacao()
        {
            return View();
        }
    }
}
