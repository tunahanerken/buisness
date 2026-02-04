using Microsoft.EntityFrameworkCore;
using ShopStock.Models;

namespace ShopStock.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<StockBatch> StockBatches => Set<StockBatch>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
            entity.Property(p => p.Sku).HasMaxLength(100);
        });

        modelBuilder.Entity<StockBatch>(entity =>
        {
            entity.Property(b => b.BatchCode).HasMaxLength(100).IsRequired();
            entity.Property(b => b.ReceivedAt).HasDefaultValueSql("NOW()");
        });
    }
}
