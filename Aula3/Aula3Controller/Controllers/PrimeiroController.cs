using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Aula3Controller.Controllers
{
    public class PrimeiroController : Controller
    {
        public string Index()
        {
            return "Hoje estou trabalhando com controllers";
        }

        public IActionResult Welcome(string name, int idade = 36)
        {
            //return HtmlEncoder.Default.Encode($"Ola {name} repeticao {numTimes}");
            ViewData["Saudacao"] = "Olá " + name;
            ViewData["Idade"] = idade;
            return View();
        }
    }
}
