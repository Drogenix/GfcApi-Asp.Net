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
        private readonly FightContext _fightContext;

        public FightsController(FightContext context)
        {
            _fightContext = context;
        }

        [HttpGet("fights")]
        public async Task<ActionResult<IEnumerable<Fight>>> GetFights()
        {
          if (_fightContext.Fight == null)
          {
              return NotFound();
          }

            var fights = _fightContext.Fight.ToList();

            return fights;
        }

        [HttpGet("lastfight/{fighterId:int}")]
        public async Task<ActionResult<Fight>> GetFight(int fighterId)
        {
            var fight = _fightContext.Fight.Where(f => f.FirstFighterId == fighterId | f.SecondFighterId == fighterId).First();

            return fight;
        }



    }
}
