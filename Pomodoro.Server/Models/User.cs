using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
	[Table("user")]
	public class User 
	{
		[Key]
		[Column("user-id")]
		public int UserId { get; set; }

		[Column("user_name")]
		public string UserName { get; set; } = string.Empty;
		

		[Column("password")]
		public string Password { get; set; }
		public required ICollection<Entry> entries { get; set; }


	}
}
