using Microsoft.EntityFrameworkCore;
using GfcWebApi.Models;

namespace Gfc.Data
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Tournament> Tournament { get; set; } = default!;
    }
}
