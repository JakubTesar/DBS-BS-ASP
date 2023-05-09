using DBS_BS.Models;
using Microsoft.EntityFrameworkCore;

namespace DBS_BS;

public class ApplicationDbContext : DbContext
{
    public DbSet<TweetEntity> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TweetEntity>()
            .HasKey(u => u.TweetId);
    }
}