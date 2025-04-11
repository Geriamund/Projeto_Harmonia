using Microsoft.AspNetCore.Mvc;
using Projeto_Harmonia.Models;
using System.Text.Json;

namespace Projeto_Harmonia.Controllers
{
	public class RotinaController : Controller
	{
		public IActionResult Index()
		{
			var rotinaJson = HttpContext.Session.GetString("RotinaRegistrada");
			var rotina = string.IsNullOrEmpty(rotinaJson) ? new Rotina() : JsonSerializer.Deserialize<Rotina>(rotinaJson);

			var diasDoMes = new List<TarefaDia>();

			var hoje = DateTime.Today;
			var primeiroDia = new DateTime(hoje.Year, hoje.Month, 1);
			var diasNoMes = DateTime.DaysInMonth(hoje.Year, hoje.Month);

			for (int i = 0; i < diasNoMes; i++)
			{
				var data = primeiroDia.AddDays(i);// cria uma nova data para cada dia do mês
				var tarefasNoDia = rotina.Tarefas.Where(t =>
					(!t.Repetir && t.DataEspecifica?.Date == data.Date) ||
					(t.Repetir && t.DiasRepetir.Contains(data.DayOfWeek))
				).ToList();// filtra as tarefas que se repetem ou são específicas para o dia

				diasDoMes.Add(new TarefaDia
				{
					Data = data,
					Tarefas = tarefasNoDia
				});
			}

			return View(diasDoMes);
		}

		public IActionResult AddTarefa()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SalvarTarefa(Tarefa t)
		{
			var rotinaJson = HttpContext.Session.GetString("RotinaRegistrada");
			if (rotinaJson == null)
				return RedirectToAction("Index", "Family");
			var rotina = JsonSerializer.Deserialize<Rotina>(rotinaJson);
			rotina.Tarefas.Add(t);
			HttpContext.Session.SetString("RotinaRegistrada", JsonSerializer.Serialize(rotina));
			return RedirectToAction("GerenciarRotina", "Family");
		}

		[HttpPost]
		public IActionResult RemoverTarefa(int indice)
		{
			var rotinaJson = HttpContext.Session.GetString("RotinaRegistrada");
			var rotina = string.IsNullOrEmpty(rotinaJson)
				? new Rotina()
				: JsonSerializer.Deserialize<Rotina>(rotinaJson);

			if (indice >= 0 && indice < rotina.Tarefas.Count)
				rotina.Tarefas.RemoveAt(indice);

			HttpContext.Session.SetString("RotinaRegistrada", JsonSerializer.Serialize(rotina));

			return RedirectToAction("GerenciarRotina", "Family");
		}


	}
}
