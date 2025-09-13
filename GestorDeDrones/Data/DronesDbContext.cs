using Microsoft.EntityFrameworkCore;
using GestorDeDrones.Models;

namespace GestorDeDrones.Data
{
    public class DronesDbContext : DbContext
    {
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Bateria> Baterias { get; set; }
        public DbSet<Mando> Mandos { get; set; }
        public DbSet<Accesorio> Accesorios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=drones.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drone>()
                .HasMany(d => d.Baterias)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Drone>()
                .HasMany(d => d.Mandos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Drone>()
                .HasMany(d => d.Accesorios)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}