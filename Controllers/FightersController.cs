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
    public class FightersController : ControllerBase
    {
        private readonly FighterContext _fighterContext;

        public FightersController(FighterContext context)
        {
            _fighterContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fighter>>> GetFighters()
        {
          if (_fighterContext.Fighter == null)
          {
              return NotFound();
          }
            return await _fighterContext.Fighter.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Fighter> GetFighter(int id)
        {
            var fighter = await _fighterContext.Fighter.FirstOrDefaultAsync(fighter => fighter.Id == id);

            return fighter;
        }

    }
}
