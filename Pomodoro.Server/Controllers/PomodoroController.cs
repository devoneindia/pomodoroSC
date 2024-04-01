using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Server.DbContexts;
using Pomodoro.Server.Models;

namespace Pomodoro.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PomodoroController : ControllerBase
	{
		private readonly EntryDbContext entryDbContext;
		//private static List<Entry> Entries = new List<Entry>();

		public PomodoroController(EntryDbContext entryDb)
		{
			entryDbContext = entryDb;
		}


		[HttpPost]
		public async Task<IActionResult> saveDevEntry([FromBody] Entry entry)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Save user data to the database
			entryDbContext.entries.Add(entry);
			await entryDbContext.SaveChangesAsync();

			return Ok(entry);
		}
		[HttpGet]
		public Entry[] GetAllEntries()
		{
			return entryDbContext.entries.ToArray();
		}

		//[HttpDelete("{id}")]
		//public IActionResult DeleteEntry(int id)
		//{
		//	var entryToRemove = Entries.FirstOrDefault(e => e.Id == id);
		//	if (entryToRemove == null)
		//	{
		//		return NotFound();
		//	}

		//	Entries.Remove(entryToRemove);
		//	return Ok();
		//}
	}
}

//{
//	[ApiController]
//	[Route("[controller]")]
//	public class PomodoroController : ControllerBase
//	{
//		private static List<Entry> Entries = new List<Entry>();

//		[HttpGet]
//		public IActionResult GetAllEntries()
//		{
//			return Ok(Entries);
//		}

//		[HttpPost]
//		public IActionResult saveDevEntry([FromBody] Entry entry)
//		{
//			Entries.Add(entry);
//			return Ok(entry);
//		}

//		[HttpDelete("{id}")]
//		public IActionResult DeleteEntry(int id)
//		{
//			var entryToRemove = Entries.FirstOrDefault(e => e.Id == id);
//			if (entryToRemove == null)
//			{
//				return NotFound();
//			}

//			Entries.Remove(entryToRemove);
//			return Ok();
//		}
//	}
//}



