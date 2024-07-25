using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheAgriApp.Models;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roleNames = { "Farmer", "Employee" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create default users if needed
        var user = new ApplicationUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com"
        };

        string userPassword = "Password123!";
        var userExist = await userManager.FindByEmailAsync(user.Email);

        if (userExist == null)
        {
            var createUser = await userManager.CreateAsync(user, userPassword);
            if (createUser.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
            }
        }
    }
}
