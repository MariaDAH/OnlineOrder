using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineOrder.Domain.Entities;
using OnlineOrder.Domain.Entities.Order;
using OnlineOrder.Domain.Entities.Product;

namespace OnlineOrder.Domain.DAOs;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Order>? Orders { get; set; }
    
    public virtual DbSet<Customer>? Customers { get; set; }
    
    public virtual DbSet<Product>? Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}