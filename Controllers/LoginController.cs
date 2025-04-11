using Microsoft.AspNetCore.Mvc;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (!string.IsNullOrEmpty(usuarioJson))
			{
				return RedirectToAction("Index", "Main");
			}
			return View();
		}

		[HttpPost]
		public IActionResult LoginComoAdmin()
		{
			var usuario = new UserModel
			{
				Nome = "Administrador",
				Email = "admin@teste.com",
				Nivel = "Admin"
			};

			HttpContext.Session.SetString("UsuarioLogado", JsonSerializer.Serialize(usuario));

			//HttpContext.Session.SetString("Teste", "Funcionou");
			//var valor = HttpContext.Session.GetString("Teste");
			//return Content($"Sessão: {valor}");


			return RedirectToAction("Index", "Main");
		}

		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			//HttpContext.Session.Remove("UsuarioLogado");
			return RedirectToAction("Index", "Home");
		}
	}
}
