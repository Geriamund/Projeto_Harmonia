﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class MainController(PHDbContext context) : Controller
	{
		private readonly PHDbContext _db = context;

		public IActionResult Index()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			var usuario = JsonSerializer.Deserialize<User>(usuarioJson);

			return View(usuario);
		}

		public IActionResult FamReg()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			var fRVM = new FamRegViewModel();
			return View(fRVM);
		}

		public IActionResult Rotina()
		{
			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (usuarioJson == null)
				return RedirectToAction("Index", "Login");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegistrarFamilia(FamRegViewModel famModel)
		{
			if (!ModelState.IsValid) return View(famModel);

			var usuarioJson = HttpContext.Session.GetString("UsuarioLogado");
			if (string.IsNullOrEmpty(usuarioJson))
				return RedirectToAction("Index", "Login");

			using var doc = JsonDocument.Parse(usuarioJson);
			var nome = doc.RootElement.GetProperty("Nome").GetString();
			var id = doc.RootElement.GetProperty("Id").GetInt32();

			var usuario = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
			var novaFamilia = new Family(famModel.Nome, famModel.Membros);

			_db.Families.Add(novaFamilia);
			await _db.SaveChangesAsync();

			if (usuario != null)
			{
				usuario.FamilyId = novaFamilia.Id;
				await _db.SaveChangesAsync();
			}
			if (nome != null)
				novaFamilia.Membros.Add(nome);

			var tempFamily = new
			{
				novaFamilia.Id,
				novaFamilia.Nome,
				novaFamilia.Membros
			};

			HttpContext.Session.SetString("FamiliaRegistrada", JsonSerializer.Serialize(tempFamily));

			return RedirectToAction("Index", "Main");
		}
	}
}
