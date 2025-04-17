using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class LoginController : Controller
	{
		private readonly PHDbContext _db;
		private readonly PasswordHasher<User> _passH;

		public LoginController(PHDbContext context)
		{
			_db = context;
			_passH = new PasswordHasher<User>();
		}

		public IActionResult Index()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (!string.IsNullOrEmpty(usuarioJson))
			{
				return RedirectToAction("Index", "Main");
			}
			return View();
		}

		public async Task<IActionResult> Login(LoginViewModel logModel)
		{
			var usuario = await _db.Users.FirstOrDefaultAsync(user => user.Email == logModel.Email);
			if (usuario == null)
			{
				TempData["Erro"] = "Usuário não encontrado.";
				return RedirectToAction("Index", "Login");
			}

			var resultado = _passH.VerifyHashedPassword(usuario, usuario.Senha, logModel.Senha);
			if (resultado == PasswordVerificationResult.Success)
			{
				HttpContext.Session.SetString("UsuarioLogado", JsonSerializer.Serialize(usuario));
				return RedirectToAction("Index", "Main");
			}
			TempData["Erro"] = "Senha incorreta.";
			return RedirectToAction("Index", "Login");
		}

		//[HttpPost]
		//public IActionResult LoginComoAdmin()
		//{
		//	var usuario = new User
		//	{
		//		Nome = "Administrador",
		//		Email = "admin@teste.com",
		//		Senha = "admin123"
		//	};

		//	HttpContext.Session.SetString("UsuarioLogado", JsonSerializer.Serialize(usuario));

		//	//HttpContext.Session.SetString("Teste", "Funcionou");
		//	//var valor = HttpContext.Session.GetString("Teste");
		//	//return Content($"Sessão: {valor}");


		//	return RedirectToAction("Index", "Main");
		//}

		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
