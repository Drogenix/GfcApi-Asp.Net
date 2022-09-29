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
    [Route("api")]
    [ApiController]
    public class FightsController : ControllerBase
    {
        private readonly GfcContext _fightContext;

        public FightsController(GfcContext context)
        {
            _fightContext = context;
        }

        [HttpGet("fights/{id}")]
        public async Task<ActionResult<IEnumerable<Fight>>> GetFights(int id)
        {
          if (_fightContext.Fights == null)
          {
              return NotFound();
          }

            var fights = await _fightContext.Fights
                .Where(fight => fight.Date < DateTime.Now && fight.FirstFighterId == id | fight.SecondFighterId == id)
                .OrderBy(fight => fight.Date)
                .ToListAsync();

            if(fights == null)
            {
                return NoContent();
            }

            return fights;
        }

    }
}
