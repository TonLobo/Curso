using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SisCad.Models;

namespace SisCad.Controllers;

public class ClienteController : Controller
{
    private static List<Cliente> _clientes = new List<Cliente>()
        { new Cliente{ClienteId=1, NomeCliente="Vagner",Email="vagner@gmail.com",Descricao="Teste"},
          new Cliente{ClienteId=2, NomeCliente="Everton",Email="everton@gmail.com",Descricao="Teste2"},
          new Cliente{ClienteId=3, NomeCliente="Ton", Email="ton@gmail.com",Descricao=""},
          new Cliente{ClienteId=4, NomeCliente="Davi", Email="davi@gmail.com",Descricao=""},
    };

    public IActionResult Index()
    {
        return View(_clientes);
    }
    [HttpGet] //apresentar o formulário ao usuário
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost] //entregar o formulário preenchido para ser processado
    public IActionResult Create(Cliente cliente)
    {

        cliente.ClienteId = _clientes.Count + 1;
        _clientes.Add(cliente);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int id) 
    {
        var cliente = _clientes.FirstOrDefault(c=>c.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
            
    }

    [HttpPost]
        public IActionResult Edit(Cliente cliente)
    {
        var existeCliente = _clientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
        if (existeCliente != null)
        {
            existeCliente.NomeCliente = cliente.NomeCliente;
            existeCliente.Email = cliente.Email;
            existeCliente.Descricao = cliente.Descricao;
        }

        return RedirectToAction("Index");

    }

    public IActionResult Delete(int id) 
    {
        var cliente = _clientes.FirstOrDefault(c => c.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }
        _clientes.Remove(cliente);
   
        return RedirectToAction("Index");
    }

   /* [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.ClienteId == id);
        if (cliente != null)
        {
            _clientes.Remove(cliente);
        }
        return RedirectToAction("Index");


    }*/
}

