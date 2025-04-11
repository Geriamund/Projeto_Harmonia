using Microsoft.AspNetCore.Mvc;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class FamilyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Gerenciar()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			var familyJson = HttpContext.Session.GetString("FamiliaRegistrada");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			if (familyJson == null)
				return RedirectToAction("Index", "Main");
			var family = JsonSerializer.Deserialize<Family>(familyJson);
			return View(family);
		}
		public IActionResult GerenciarMembros()
		{
			var familyJson = HttpContext.Session.GetString("FamiliaRegistrada");
			if (familyJson == null)
				return RedirectToAction("Index", "Main");
			var family = JsonSerializer.Deserialize<Family>(familyJson);
			return View(family);
		}

		public IActionResult GerenciarRotina()
		{
			var rotinaJson = HttpContext.Session.GetString("RotinaRegistrada");
			var rotina = rotinaJson == null ? new Rotina() : JsonSerializer.Deserialize<Rotina>(rotinaJson);
			HttpContext.Session.SetString("RotinaRegistrada", JsonSerializer.Serialize(rotina));
			return View(rotina);
		}

		[HttpPost]
		public IActionResult SalvarMembros(Family family)
		{
			HttpContext.Session.SetString("FamiliaRegistrada", JsonSerializer.Serialize(family));
			return RedirectToAction("Index", "Family");
		}

	}
}
