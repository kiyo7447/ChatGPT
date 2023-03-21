
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreTuningWebApp.Models;


namespace EFCoreTuningWebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyController : ControllerBase
	{
		private readonly MyDbContext _context;

		public MyController(MyDbContext context)
		{
			_context = context;
		}

		// GET: api/MyController
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MyEntity>>> GetMyEntities()
		{
			return await _context.MyEntities.ToListAsync();
		}

		// GET: api/MyController/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MyEntity>> GetMyEntity(int id)
		{
			var myEntity = await _context.MyEntities.FindAsync(id);

			if (myEntity == null)
			{
				return NotFound();
			}

			return myEntity;
		}

		// PUT: api/MyController/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMyEntity(int id, MyEntity myEntity)
		{
			if (id != myEntity.Id)
			{
				return BadRequest();
			}

			_context.Entry(myEntity).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MyEntityExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/MyController
		[HttpPost]
		public async Task<ActionResult<MyEntity>> CreateMyEntity(MyEntity myEntity)
		{
			_context.MyEntities.Add(myEntity);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMyEntity), new { id = myEntity.Id }, myEntity);
		}

		// DELETE: api/MyController/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMyEntity(int id)
		{
			var myEntity = await _context.MyEntities.FindAsync(id);
			if (myEntity == null)
			{
				return NotFound();
			}

			_context.MyEntities.Remove(myEntity);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MyEntityExists(int id)
		{
			return _context.MyEntities.Any(e => e.Id == id);
		}
	}
}

