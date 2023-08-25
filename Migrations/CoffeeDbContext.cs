using l07_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace l07_ef.Migrations;

public class CoffeeDbContext : DbContext
{
    public DbSet<Coffee> Coffee { get; set; }
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coffee>(entity =>
        {
            entity.HasKey(e => e.CoffeeId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Price).IsRequired();
        });
    }
}




