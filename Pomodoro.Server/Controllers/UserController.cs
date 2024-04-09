using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pomodoro.Server.DbContexts;
using Pomodoro.Server.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly EntryDbContext _entryDbContext;

		public UserController(ILogger<UserController> logger, EntryDbContext entryDbContext)
		{
			_logger = logger;
			_entryDbContext = entryDbContext;
		}

		[HttpPost]
		public async Task<IActionResult> SaveUser([FromBody] User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				_entryDbContext.users.Add(user);
				await _entryDbContext.SaveChangesAsync();
				_logger.LogInformation("User data has been saved to the database.");
				return Ok(user);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while saving user: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
			}
		}

		[HttpGet]
		public IActionResult GetUser()
		{
			try
			{
				var users = _entryDbContext.users.ToList();
				_logger.LogInformation("Retrieved users from the database.");
				return Ok(users);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while fetching users: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
			}
		}
	}
}


//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Pomodoro.Server.DbContexts;
//using Pomodoro.Server.Models;

//namespace Pomodoro.Server.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class UserController : ControllerBase
//	{

//		private readonly ILogger<UserController> _logger01;
//		private readonly EntryDbContext _entryDbContext;
//		public UserController(ILogger<UserController> loggers, EntryDbContext entryDbContext)
//		{
//			_logger01 = loggers;
//			_entryDbContext = entryDbContext;
//		}
//		[HttpPost]
//		public async Task<IActionResult> saveUser([FromBody] User user)
//		{
//			if (!ModelState.IsValid)
//			{
//				return BadRequest(ModelState);
//			}

//			try
//			{

//				_entryDbContext.users.Add(user);
//				await _entryDbContext.SaveChangesAsync();
//				_logger01.LogInformation($"The data has been posted to the Postgresql Database.");
//				return Ok(user);
//			}
//			catch (Exception ex)
//			{
//				_logger01.LogError($"An error occurred while saving entry: {ex}");
//				return StatusCode(500, "An error occurred while processing your request.");
//			}
//		}
//		[HttpGet]
//		public IActionResult getUser()
//		{
//			try
//			{
//				var entries = _entryDbContext.users.ToArray();
//				_logger01.LogInformation($"The values from the Database is UP-TO-DATE!.");
//				return Ok(entries);
//			}
//			catch (Exception ex)
//			{
//				_logger01.LogError($"An error occurred while fetching entries: {ex}");
//				return StatusCode(500, "An error occurred while processing your request.");
//			}
//		}

//	}
//}
