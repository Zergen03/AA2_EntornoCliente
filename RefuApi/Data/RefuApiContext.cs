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
            modelBuilder.Entity<ScheduleAssignment>()
                .HasKey(sa => new { sa.UserId, sa.ZoneId, sa.ScheduleId });

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.User)
                .WithMany()
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.Zone)
                .WithMany()
                .HasForeignKey(sa => sa.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.Schedule)
                .WithMany()
                .HasForeignKey(sa => sa.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ScheduleAssignment> ScheduleAssignments { get; set; }
    }
}
