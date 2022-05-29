using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Friendship>().HasKey(f => new { f.RequestedBy, f.RequestedTo });
            modelBuilder.Entity<Friendship>()
              .HasOne(f => f.RequestedBy)
              .WithMany()
              .HasForeignKey(f => f.RequestedBy_Id);

            modelBuilder.Entity<Friendship>()
            .HasOne(f => f.RequestedTo)
            .WithMany()
            .HasForeignKey(f => f.RequestedTo_Id);*/
        }
    }
}