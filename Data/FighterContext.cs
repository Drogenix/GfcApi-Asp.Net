using Microsoft.EntityFrameworkCore;
using GfcWebApi.Models;

namespace Gfc.Data
{
    public class FighterContext : DbContext
    {
        public FighterContext(DbContextOptions<FighterContext> options)
            : base(options)
        {
        }

        public DbSet<Fighter> Fighter { get; set; } = default!;
    }
}
