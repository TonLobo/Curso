// Exemplo de controlador de conta
using Loja.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Loja.Models;
using Microsoft.Identity.Client;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Validação do usuário (exemplo simples)
        if (username == "emusk" && password == "teste123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "username")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Descontos");
        }

        ModelState.AddModelError(string.Empty, "Sem Permissão. Entre em contato com o Administrador.");
        return View();
    }

    /*public async Task<IActionResult> Login([FromForm] LoginModel loginModel)
    {
        if (loginModel.Username != "admin" || 
            loginModel.Password != "admin")
            {
                ViewBag.Fail = true;
        
                 return View();
            }
        //simulando um usuário 
        var user = new
        {
            Id = Guid.NewGuid(),
            Name = "Administrador"
        };

        List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            ];
        var authScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        var identity = new ClaimsIdentity(claims, authScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(authScheme, principal, new AuthenticationProperties
        {
            IsPersistent = loginModel.Equals(loginModel)
        });

        if(!String.IsNullOrWhiteSpace(loginModel.Password))
        {
            return Redirect(loginModel.Password);
        }

        return RedirectToRoute("Desconto.Index");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToRoute("Auth.Login");
    }*/

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
