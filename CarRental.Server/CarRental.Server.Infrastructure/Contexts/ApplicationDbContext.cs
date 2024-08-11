using CarRental.Server.Domain.Shared;
using CarRental.Server.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nlabs.GenericRepository;

namespace CarRental.Server.Infrastructure.Contexts;
internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();

        builder.Entity<AppUser>()
            .Property(p => p.Id)
            .HasColumnType("varchar(61)");

        builder.Entity<AppUser>()
            .Property(p => p.FirstName)
            .HasConversion(firstName => firstName.Value, value => Name.Create(value))
            .HasColumnType("varchar(50)");

        builder.Entity<AppUser>()
            .Property(p => p.LastName)
            .HasConversion(lastName => lastName.Value, value => Name.Create(value))
            .HasColumnType("varchar(50)");

        builder.Entity<AppRole>()
            .Property(p => p.Id)
            .HasColumnType("varchar(61)");

        builder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.Entity<UserRole>()
            .Property(p => p.UserId)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");

        builder.Entity<UserRole>()
            .Property(p => p.RoleId)
            .HasConversion(id => id.Value, value => new Identity(value))
            .HasColumnType("varchar(61)");

        builder.Entity<Setting>()
            .Property(p => p.Id)
            .HasColumnType("varchar(61)");

        builder.Entity<Setting>()
            .Property(p => p.Image)
            .HasConversion(img => img.Value, val => Name.Create(val))
            .HasColumnType("varchar(80)");

        builder.Entity<Setting>()
            .Property(p => p.Email)
            .HasConversion(email => email.Value, value => Email.Create(value))
            .HasColumnType("varchar(80)");

    }
}
