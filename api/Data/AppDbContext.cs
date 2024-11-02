using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UserToken> UserTokens { get; set; } = default!;
        public DbSet<Advertisement> Advertisements { get; set; } = default!;
        public DbSet<AdvertismentImage> AdvertismentImages { get; set; } = default!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToken>()
                        .HasOne(ut => ut.User)
                        .WithMany(u => u.Tokens)
                        .HasForeignKey(ut => ut.UserID);

            modelBuilder.Entity<AdvertismentImage>()
            .HasOne(ai => ai.Advertisement)
            .WithMany(a => a.AdvertismentImages)
            .HasForeignKey(ai => ai.AdvertismentID);
        }
    }
}
