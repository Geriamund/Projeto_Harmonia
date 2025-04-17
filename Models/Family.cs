using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Harmonia.Models
{
	public class Family
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }

		[NotMapped]
		public List<string> Membros { get; set; } = new();

		public List<User> Usuarios { get; set; } = new();

		public Family(string nome, List<string> membros)
		{
			Nome = nome;
			Membros = membros;
		}
		public Family() { }
	}
}
