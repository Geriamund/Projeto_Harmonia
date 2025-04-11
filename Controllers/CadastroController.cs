using Microsoft.AspNetCore.Mvc;

namespace Projeto_Harmonia.Controllers
{
	public class CadastroController : Controller
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
	}
}
