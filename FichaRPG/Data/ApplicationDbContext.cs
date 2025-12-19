using Microsoft.EntityFrameworkCore;
using FichaRPG.Models;

namespace FichaRPG.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personagem> Personagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Classe).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ImagemUrl).HasMaxLength(500);
            });
        }
    }
}
