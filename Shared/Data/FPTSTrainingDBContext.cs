using Shared.Data.EntityConfig;
using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Shared.Data;

public class FPTSTrainingDBContext : DbContext
{
    private readonly DbContextOptions<FPTSTrainingDBContext> _option;
    public FPTSTrainingDBContext(DbContextOptions<FPTSTrainingDBContext> options) : base(options)
    {

        _option = options;
    }
    public DbSet<Buyers> Buyers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("HANVV");
        modelBuilder.ApplyConfiguration(new BuyerConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderItemConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
    }

}
