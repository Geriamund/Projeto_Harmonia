namespace Projeto_Harmonia.Models
{
	public class TarefaDia
	{
		public DateTime Data { get; set; }
		public List<Tarefa> Tarefas { get; set; } = new();
	}
}
