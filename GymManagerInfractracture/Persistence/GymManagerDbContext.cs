using Microsoft.EntityFrameworkCore;
using GymManagerApplication.Entities;

namespace GymManagerInfractracture.Persistence
{
    public class GymManagerDbContext : DbContext
    {
        public GymManagerDbContext(DbContextOptions<GymManagerDbContext> options) : base(options)
        {
        }

        public DbSet<GymManager> GymManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GymManager>()
                .HasKey(g => g.Id); // Dodaj konfigurację klucza głównego

         
            modelBuilder.Entity<GymManager>()
                .OwnsOne(g => g.Contact);
        }
    }
}