using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RefuApi.Models;

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
                .HasKey(sa => new { sa.UserId, sa.ScheduleId });

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.User)
                .WithMany(u => u.ScheduleAssignments)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.Schedule)
                .WithMany(s => s.ScheduleAssignments)
                .HasForeignKey(sa => sa.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Zone)
                .WithMany(z => z.Schedules)
                .HasForeignKey(s => s.ZoneId)
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
