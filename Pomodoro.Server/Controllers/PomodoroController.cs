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
	public class PomodoroController : ControllerBase
	{
		private readonly ILogger<PomodoroController> _logger;
		private readonly EntryDbContext _entryDbContext;

		public PomodoroController(ILogger<PomodoroController> logger, EntryDbContext entryDbContext)
		{
			_logger = logger;
			_entryDbContext = entryDbContext;
		}

		[HttpPost]
		public async Task<IActionResult> saveDevEntry([FromBody] Entry entry)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				
				_entryDbContext.entries.Add(entry);
				await _entryDbContext.SaveChangesAsync();
				_logger.LogInformation($"The data has been posted to the Postgresql Database.");
				return Ok(entry);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while saving entry: {ex}");
				return StatusCode(500, "An error occurred while processing your request.");
			}
		}

		[HttpGet]
		public IActionResult GetAllEntries()
		{
			try
			{
				var entries = _entryDbContext.entries.ToArray();
				_logger.LogInformation($"The values from the Database is UP-TO-DATE!.");
				return Ok(entries);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while fetching entries: {ex}");
				return StatusCode(500, "An error occurred while processing your request.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEntry(int id)
		{
			try
			{
				var entryToRemove = await _entryDbContext.entries.FindAsync(id);
				if (entryToRemove == null)
				{
					return NotFound();
				}

				_entryDbContext.entries.Remove(entryToRemove);
				await _entryDbContext.SaveChangesAsync();
				_logger.LogInformation($"The data has been Deleted from the Postgresql Database.");
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while deleting entry with ID {id}: {ex}");
				return StatusCode(500, "An error occurred while processing your request.");
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
//	public class PomodoroController : ControllerBase
//	{
//		private readonly ILogger<PomodoroController> _logger;
//		private readonly EntryDbContext entryDbContext;
//		private static List<Entry> Entries = new List<Entry>();
//		public PomodoroController(ILogger<PomodoroController> logger)
//		{
//			_logger = logger;
//		}

//		public PomodoroController(EntryDbContext entryDb)
//		{
//			entryDbContext = entryDb;
//		}


//		[HttpPost]
//		public async Task<IActionResult> saveDevEntry([FromBody] Entry entry)
//		{
//			if (!ModelState.IsValid)
//			{
//				return BadRequest(ModelState);
//			}

//			// Save user data to the database
//			entryDbContext.entries.Add(entry);
//			await entryDbContext.SaveChangesAsync();

//			return Ok(entry);
//		}

//		[HttpGet]
//		public Entry[] GetAllEntries()
//		{
//			try
//			{
//				var entry = entryDbContext.entries.ToArray();
//				return Ok(entry);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError($"An error occurred while fetching entries: {ex}");
//				return StatusCode(500, "An error occurred while processing your request.");
//			}
//		}

//		[HttpDelete("{id}")]
//		public async Task<IActionResult> DeleteEntry(int id)
//		{
//			var entryToRemove = await entryDbContext.entries.FindAsync(id);
//			if (entryToRemove == null)
//			{
//				return NotFound();
//			}

//			entryDbContext.entries.Remove(entryToRemove);
//			await entryDbContext.SaveChangesAsync();

//			return Ok();
//		}
//	}
//}



