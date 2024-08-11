using CarRental.Server.Domain.Blogs;
using CarRental.Server.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Nlabs.GenericRepository;

namespace CarRental.Server.Infrastructure.Contexts;

internal sealed class BlogDbContext : DbContext, IUnitOfWork
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Blog>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");


        builder.Entity<Blog>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value));

        builder.Entity<Blog>()
        .Property(p => p.Title)
            .HasConversion(title => title.Value, value => Name.Create(value))
            .HasColumnType("varchar(80)");
    }
}