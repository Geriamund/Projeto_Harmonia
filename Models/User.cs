using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Harmonia.Models
{
	[Index(nameof(Email), IsUnique = true)]
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Senha { get; set; }

		public User(string nome, string email, string senha)
		{
			Nome = nome;
			Email = email;
			Senha = senha;
		}
		public User(){}
	}
}