using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Domain.Models;


namespace Repository.Infrastucture;


public partial class EFCoreDBContext : DbContext
{
    public string ConnectionString { get; set; }

    public EFCoreDBContext()
    {
    }

    public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ORM_DEMO;User Id=sa;Password=MD123!@#;TrustServerCertificate=true");
        //"Server=(localdb)\\MSSQLLocalDB;Database=ORM_DEMO;User Id=sa;Password=MD123!@#;"
        optionsBuilder.LogTo(msg =>
        {
            Console.WriteLine(msg);
        }, Microsoft.Extensions.Logging.LogLevel.Information);

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

}
