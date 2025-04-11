using Microsoft.AspNetCore.Mvc;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class MainController : Controller
	{
		public IActionResult Index()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			var usuario = JsonSerializer.Deserialize<UserModel>(usuarioJson);

			return View(usuario);
		}
		public IActionResult FamReg()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			var usuario = JsonSerializer.Deserialize<UserModel>(usuarioJson);
			var fRVM = new FamRegViewModel();
			return View(fRVM);
		}
		public IActionResult Rotina()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			var usuario = JsonSerializer.Deserialize<UserModel>(usuarioJson);

			return View();
		}
		
		public IActionResult Registrar(Family family)
		{
			HttpContext.Session.SetString("FamiliaRegistrada", JsonSerializer.Serialize(family));
			return RedirectToAction("Index", "Main");
		}
		

	}
}
