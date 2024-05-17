using Microsoft.AspNetCore.Mvc;
using CalcIdade.Models;

namespace CalcIdade.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalcularIdade(User user)
        {
            int idade = DateTime.Now.Year - user.DataNascimento.Year;
            if (DateTime.Now < user.DataNascimento.AddYears(idade)) idade--;

            ViewBag.Idade = idade;
            return View("Resultado");

        }
    }
}
