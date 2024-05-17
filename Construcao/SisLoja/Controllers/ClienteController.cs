using Microsoft.AspNetCore.Mvc;
using SisLoja.Models;

namespace SisLoja.Controllers
{
    public class ClienteController : Controller

    {
        private static List<Cliente> _clientes = new List<Cliente>()
            {
                new Cliente { ClienteId = 1, NomeCliente = "Vagner", Email = "vagner@example.com" },
                new Cliente { ClienteId = 2, NomeCliente = "Marco", Email = "marco@uol.com" },
                new Cliente { ClienteId = 3, NomeCliente = "Eduardo", Email = "eduardo@globo.com" },
                new Cliente { ClienteId = 4, NomeCliente = "Everton", Email = "everton@gmail.com" }
            };
        public IActionResult Index()
        {
            return View(_clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                cliente.ClienteId = _clientes.Count > 0 ? _clientes.Max(c => c.ClienteId) + 1 : 1;
                _clientes.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
    }
}
