using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheAgriApp.Models;  // Adjust the namespace according to your project

namespace TheAgriApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext with DI container
            builder.Services.AddDbContext<TheAgriContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("Agri")));

            // Add Identity services
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
 .AddEntityFrameworkStores<TheAgriContext>()
 .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Ensure authentication middleware is added
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}