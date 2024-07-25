using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheAgriPart3.Areas.Identity.Data;
using TheAgriPart3.Data;
namespace TheAgriPart3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("TheAgriPart3ContextConnection") ?? throw new InvalidOperationException("Connection string 'TheAgriPart3ContextConnection' not found.");

            builder.Services.AddDbContext<TheAgriPart3Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Farmer>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TheAgriPart3Context>();

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

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
