using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gfc.Data;
using GfcWebApi.Models;

namespace Gfc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly GfcContext _context;

        public TournamentsController(GfcContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        [HttpGet("near")]
        public async Task<ActionResult<Tournament>> GetNearTournament()
        {
            var tournament = await _context.Tournaments
                .OrderByDescending(item => item.StartDate)
                .Where(item => DateTime.Now  < item.StartDate)
                .FirstOrDefaultAsync();

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        [HttpGet("future")]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetFutureTournaments()
        {
            if (_context.Tournaments == null)
            {
                return NotFound();
            }

            var tournaments = await _context.Tournaments
                .Where(item => DateTime.Now < item.StartDate)
                .OrderBy(fight => fight.StartDate)
                .ToListAsync();

            if (tournaments == null)
            {
                return NoContent();
            }

            return tournaments;
        }

        [HttpGet("ended")]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetEndedTournaments()
        {
            if (_context.Tournaments == null)
            {
                return NotFound();
            }
            var tournaments = await _context.Tournaments.Where(tournament => DateTime.Now > tournament.StartDate).OrderBy(tournament => tournament.StartDate).ToListAsync();

            if (tournaments == null)
            {
                return NoContent();
            }

            return tournaments;
        }


        //// PUT: api/Tournaments1/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        //{
        //    if (id != tournament.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tournament).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.Tournaments.Any(item => item.Id == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Tournaments1
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        //{
        //    _context.Tournaments.Add(tournament);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        //}

        //// DELETE: api/Tournaments1/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTournament(int id)
        //{
        //    var tournament = await _context.Tournaments.FindAsync(id);
        //    if (tournament == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tournaments.Remove(tournament);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
