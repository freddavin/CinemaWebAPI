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

            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Cinema)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(s => s.CinemaId);

            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Filme)
                .WithMany(f => f.Sessoes)
                .HasForeignKey(s => s.FilmeId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
