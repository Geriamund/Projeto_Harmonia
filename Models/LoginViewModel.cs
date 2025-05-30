using System.ComponentModel.DataAnnotations;
namespace Projeto_Harmonia.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "O e-mail � obrigat�rio.")]
		[EmailAddress(ErrorMessage = "E-mail inv�lido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "A senha � obrigat�ria.")]
		[DataType(DataType.Password)]
		public string Senha { get; set; }
	}
}
