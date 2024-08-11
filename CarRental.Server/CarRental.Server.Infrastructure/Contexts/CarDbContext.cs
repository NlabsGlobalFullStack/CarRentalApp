using CarRental.Server.Domain.Cars;
using CarRental.Server.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Nlabs.GenericRepository;

namespace CarRental.Server.Infrastructure.Contexts;

internal sealed class CarDbContext : DbContext, IUnitOfWork
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");


        builder.Entity<Category>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value));

        builder.Entity<Category>()
        .Property(p => p.Name)
            .HasConversion(name => name.Value, value => Name.Create(value))
            .HasColumnType("varchar(80)");

        builder.Entity<Car>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");


        builder.Entity<Car>()
            .Property(p => p.CategoryId)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");

        builder.Entity<Car>()
        .Property(p => p.Plate)
            .HasConversion(name => name.Value, value => Plate.Create(value))
            .HasColumnType("varchar(15)");

        builder.Entity<Car>()
        .Property(p => p.Color)
            .HasConversion(color => color.Value, value => new Color(value))
            .HasColumnType("varchar(15)");
    }
}
