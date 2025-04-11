using System.ComponentModel.DataAnnotations;

namespace Projeto_Harmonia.Models
{
	public class CadastroViewModel
	{
		[Required(ErrorMessage = "O nome � obrigat�rio.")]
		[Display(Name = "Nome completo")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O e-mail � obrigat�rio.")]
		[EmailAddress(ErrorMessage = "E-mail inv�lido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "A senha � obrigat�ria.")]
		[StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no m�nimo 6 caracteres.")]
		[DataType(DataType.Password)]
		public string Senha { get; set; }

		[Required(ErrorMessage = "A confirma��o de senha � obrigat�ria.")]
		[Compare("Senha", ErrorMessage = "As senhas n�o coincidem.")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirmar senha")]
		public string ConfirmarSenha { get; set; }
	}
}
