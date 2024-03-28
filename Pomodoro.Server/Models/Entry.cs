using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
	[Table("entry")]
	public class Entry
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("dev-name")]
		public string DevName { get; set; }

		[Column("date")]
		public DateOnly Date { get; set; }

		[Column("starting-time")]
		public string StartingTime { get; set; }

		[Column("ending-time")]
		public string EndingTime { get; set; }

		[Column("comment")]
		public string Comment { get; set; }
	}
}
