using Microsoft.EntityFrameworkCore;
using GymManagerApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymManagerInfractracture.Persistence
{
    public class GymManagerDbContext : IdentityDbContext
    {
        public GymManagerDbContext(DbContextOptions<GymManagerDbContext> options) : base(options)
        {
        }

        public DbSet<GymManager> GymManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GymManager>()
                .HasKey(g => g.Id); // konfiguracja klucza głównego

         
            modelBuilder.Entity<GymManager>()
                .OwnsOne(g => g.Contact);
        }
    }
}