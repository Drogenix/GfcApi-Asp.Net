using Microsoft.EntityFrameworkCore;
using GfcWebApi.Models;

namespace Gfc.Data
{
    public class FightContext : DbContext
    {
        public FightContext(DbContextOptions<FightContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Fight> Fight { get; set; } = default!;
    }
}
