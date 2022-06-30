using Microsoft.EntityFrameworkCore;
using CinemaWebAPI.Models;

namespace CinemaWebAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Cinema)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Cinema>(c => c.EnderecoId);

            modelBuilder.Entity<Gerente>()
                .HasMany(g => g.CinemasGerenciados)
                .WithOne(c => c.Gerente)
                .HasForeignKey(c => c.GerenteId);
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
    }
}
