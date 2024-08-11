using CarRental.Server.Domain.Shared;
using CarRental.Server.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Server.WebAPI.Middlewares;
public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = Name.Create("Cuma"),
                    LastName = Name.Create("Köse"),
                    EmailConfirmed = true
                };

                userManager.CreateAsync(user, "1").Wait();
            }
        }
    }
}