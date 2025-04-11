using System.ComponentModel.DataAnnotations;

namespace Projeto_Harmonia.Models
{
	public class Tarefa
	{
		[Required]
		public string Nome { get; set; }

		public string Descricao { get; set; }

		public bool Repetir { get; set; }

		public List<DayOfWeek> DiasRepetir { get; set; } = new();

		[DataType(DataType.Date)]
		public DateTime? DataEspecifica { get; set; }

		public List<string> Membros { get; set; } = new();

		public List<string> DaystoDias
		{
			get
			{
				var diasPtBr = new Dictionary<DayOfWeek, string>
			{
				{ DayOfWeek.Sunday, "Dom" },
				{ DayOfWeek.Monday, "Seg" },
				{ DayOfWeek.Tuesday, "Ter" },
				{ DayOfWeek.Wednesday, "Qua" },
				{ DayOfWeek.Thursday, "Qui" },
				{ DayOfWeek.Friday, "Sex" },
				{ DayOfWeek.Saturday, "Sáb" }
			};

				return DiasRepetir.OrderBy(d => (int)d).Select(d => diasPtBr[d])
			.ToList();
			}
		}
	}
}
