using Microsoft.EntityFrameworkCore;
using RefuApi.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RefuApi.Data
{
    public class RefuApiContext : DbContext
    {
        public RefuApiContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave compuesta para la tabla intermedia
            // modelBuilder.Entity<UserEntrada>()
            //     .HasKey(ue => new { ue.UserId, ue.EntradaId });

            // // Relaciones
            // modelBuilder.Entity<UserEntrada>()
            //     .HasOne(ue => ue.User)
            //     .WithMany(u => u.UserEntradas)
            //     .HasForeignKey(ue => ue.UserId);

            // modelBuilder.Entity<UserEntrada>()
            //     .HasOne(ue => ue.Entrada)
            //     .WithMany(e => e.UserEntradas)
            //     .HasForeignKey(ue => ue.EntradaId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        // public DbSet<Zona> Zonas { get; set; }
        // public DbSet<Horario> Horarios { get; set; }
        // public DbSet<Entrada> Entradas { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserEntrada> UserEntradas { get; set; }
    }
}
