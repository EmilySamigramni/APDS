using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalYearPoePart3.Areas.Identity.Data;
namespace FinalYearPoePart3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("FinalYearPoePart3ContextConnection") ?? throw new InvalidOperationException("Connection string 'FinalYearPoePart3ContextConnection' not found.");

            builder.Services.AddDbContext<FinalYearPoePart3Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<FarmerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FinalYearPoePart3Context>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
