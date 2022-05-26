using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<User>()
            .HasOne(p => p.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId);

            modelBuilder
            .Entity<Profile>()
            .HasOne(c => c.Theme)
            .WithOne(c => c.Profile)
            .HasForeignKey<Theme>(c => c.ProfileId);

            modelBuilder
            .Entity<Profile>()
            .HasMany(c => c.Hobbies)
            .WithOne(c => c.Profile)
            .HasForeignKey(c => c.ProfileId);

            modelBuilder
            .Entity<Profile>()
            .HasMany(c => c.Songs)
            .WithOne(c => c.Profile)
            .HasForeignKey(c => c.ProfileId);


        }
    }
}