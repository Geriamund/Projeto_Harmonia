using Microsoft.AspNetCore.Mvc;
using Projeto_Harmonia.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Harmonia.Controllers
{
	public class CadastroController : Controller
	{
		private readonly PHDbContext _db;

		public CadastroController(PHDbContext context) => _db = context;

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
		public async Task<IActionResult> CadastroUser(CadastroViewModel cadModel)
		{
			if (!ModelState.IsValid) return View(cadModel);

			//Encriptar senha antes de salva no db
			string hashedSenha = new PasswordHasher<User>().HashPassword(null, cadModel.Senha);

			var novoUsuario = new User(cadModel.Nome, cadModel.Email, hashedSenha);

			_db.Users.Add(novoUsuario);
			await _db.SaveChangesAsync();


			TempData["SucessMS"] = "Cadastro realizado com sucesso!";
			return RedirectToAction("Index", "Login");
		}

	}
}
