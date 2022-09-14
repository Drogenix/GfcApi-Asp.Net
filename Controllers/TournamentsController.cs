using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
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
        private readonly TournamentContext _tournamentContext;

        public TournamentsController(TournamentContext tournamentContext, FightContext fightContext, FighterContext fighterContext)
        {
            _tournamentContext = tournamentContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
          if (_tournamentContext.Tournament == null)
          {
              return NotFound();
          }

            var tournaments = _tournamentContext.Tournament.ToList();

            return tournaments;
        }

        [HttpGet("{id}")]
        public async Task<Tournament> GetTounament(int id)
        {
            var tournament = await _tournamentContext.Tournament.FirstAsync(tournament => tournament.Id == id);

            return tournament;
        }

    }
}
