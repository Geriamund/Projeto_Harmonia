using System.ComponentModel.DataAnnotations;

namespace Projeto_Harmonia.Models
{
	public class Family
	{
		public string Nome { get; set; }
		public List<string> Membros { get; set; } = new();
	}
}
