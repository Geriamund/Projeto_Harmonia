using System.ComponentModel.DataAnnotations;

namespace Projeto_Harmonia.Models
{
	public class FamRegViewModel
	{
		[Required(ErrorMessage = "O nome da família é obrigatório.")]
		[StringLength(100)]
		public string Nome { get; set; }

		public List<string> Membros { get; set; } = new();

	}
}
