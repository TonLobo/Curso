using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutoController : ControllerBase
	{
		[HttpGet]
		public string Saudacao()
		{
			return $"{DateTime.Now.ToShortDateString()} - Bem Vindo";
		}
	}
}
