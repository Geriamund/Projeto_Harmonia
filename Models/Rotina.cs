using System.ComponentModel.DataAnnotations;

namespace Projeto_Harmonia.Models
{
	public class Rotina
	{
		public List<Tarefa> Tarefas { get; set; } = [];
	}
}
