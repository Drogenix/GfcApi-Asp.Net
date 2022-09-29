using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gfc.Data;
using GfcWebApi.Models;
using Microsoft.AspNetCore.Html;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;

namespace Gfc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightersController : ControllerBase
    {
        private readonly GfcContext _fighterContext;

        public FightersController(GfcContext context)
        {
            _fighterContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fighter>>> GetFighters()
        {
          if (_fighterContext.Fighters == null)
          {
              return NotFound();
          }
            return await _fighterContext.Fighters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Fighter> GetFighter(int id)
        {
            var fighter = await _fighterContext.Fighters.FirstOrDefaultAsync(fighter => fighter.Id == id);

            //HtmlContentBuilder contentBuilder = new();

            //HtmlString htmlString = new HtmlString("<p>Привет всем</p>");

            //contentBuilder = (HtmlContentBuilder)contentBuilder.AppendHtmlLine("<p>Привет всем</p>");

            //var fileName = @"C:\blogname.html";

            //StreamWriter sw = new StreamWriter(fileName, true);

            //contentBuilder.WriteTo(sw, HtmlEncoder.Default);

            //sw.Close();

            //Console.WriteLine(AppContext.BaseDirectory);

            return fighter;
        }
        [HttpGet("ratings")]
        public async Task<IEnumerable<Fighter>> GetFightersRatings()
        {
            var fighters = await _fighterContext.Fighters.Where(item => item.Rating != 0).OrderBy(item => item.Weight).ThenBy(item=> item.Rating).ToListAsync();

            return fighters;
        }
        [HttpGet("pfpratings")]
        public async Task<IEnumerable<Fighter>> GetFightersPfpRatings()
        {
            var fighters = await _fighterContext.Fighters.Where(item => item.PfpRating != 0).OrderBy(item => item.PfpRating).ToListAsync();

            return fighters;
        }



    }
}
