using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Server.Models
{
	[Table("user")]
	public class User 
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("user-name")]
		public string Username { get; set; }

		[Column("password")]
		public string Password { get; set; }

	}
}
