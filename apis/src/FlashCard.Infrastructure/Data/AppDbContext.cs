using FlashCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCard.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Card>()
            .HasIndex(p => new { p.Title, p.Description })
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("english");

        base.OnModelCreating(builder);
    }
}
