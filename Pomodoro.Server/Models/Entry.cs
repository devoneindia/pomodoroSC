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

		[Column("user-name")]
		public string? userName { get; set; }

		[Column("date")]
		public string? Date { get; set; }

		[Column("starting-time")]
		public string? Startingtime { get; set; }

		[Column("ending-time")]
		public string? Endingtime { get; set; }

		[Column("comment")]
		public string? Comment { get; set; }

		[Column("total-time")]
		public string? Totaltime { get; set; }

		[ForeignKey("user")]
		[Column("user-id")]
		public int UserId { get; set; }
	}
}
