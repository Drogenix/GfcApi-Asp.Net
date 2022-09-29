using Microsoft.EntityFrameworkCore;
using GfcWebApi.Models;
using Gfc.Models;
using static NuGet.Packaging.PackagingConstants;

namespace Gfc.Data
{
    public class GfcContext : DbContext
    {
        public GfcContext(DbContextOptions<GfcContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Tournament> Tournaments { get; set; } = default!;

        public DbSet<Fighter> Fighters { get; set; } = default!;

        public DbSet<Fight> Fights { get; set; } = default!;

        public DbSet<Blog> Blogs { get; set; } = default!;
    }
}
