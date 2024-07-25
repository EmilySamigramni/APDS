using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmsPoeP2.Data;
namespace EmsPoeP2
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("EmsPoeP2ContextConnection") ?? throw new InvalidOperationException("Connection string 'EmsPoeP2ContextConnection' not found.");

            builder.Services.AddDbContext<EmsPoeP2Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmsPoeP2Context>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Configuration.AddJsonFile("appsettings.json");


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
