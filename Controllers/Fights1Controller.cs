using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gfc.Data;
using GfcWebApi.Models;

namespace Gfc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fights1Controller : ControllerBase
    {
        private readonly FightContext _context;

        public Fights1Controller(FightContext context)
        {
            _context = context;
        }

        // GET: api/Fights1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fight>>> GetFight()
        {
          if (_context.Fight == null)
          {
              return NotFound();
          }
            return await _context.Fight.ToListAsync();
        }

        // GET: api/Fights1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fight>> GetFight(int id)
        {
          if (_context.Fight == null)
          {
              return NotFound();
          }
            var fight = await _context.Fight.FindAsync(id);

            if (fight == null)
            {
                return NotFound();
            }

            return fight;
        }

        // PUT: api/Fights1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFight(int id, Fight fight)
        {
            if (id != fight.Id)
            {
                return BadRequest();
            }

            _context.Entry(fight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FightExists(id))
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

        // POST: api/Fights1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fight>> PostFight(Fight fight)
        {
          if (_context.Fight == null)
          {
              return Problem("Entity set 'FightContext.Fight'  is null.");
          }
            _context.Fight.Add(fight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFight", new { id = fight.Id }, fight);
        }

        // DELETE: api/Fights1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFight(int id)
        {
            if (_context.Fight == null)
            {
                return NotFound();
            }
            var fight = await _context.Fight.FindAsync(id);
            if (fight == null)
            {
                return NotFound();
            }

            _context.Fight.Remove(fight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FightExists(int id)
        {
            return (_context.Fight?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
