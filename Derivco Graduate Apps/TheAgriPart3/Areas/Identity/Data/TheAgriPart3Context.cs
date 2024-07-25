using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheAgriPart3.Areas.Identity.Data;

namespace TheAgriPart3.Data;

public class TheAgriPart3Context : IdentityDbContext<Farmer>
{
    public TheAgriPart3Context(DbContextOptions<TheAgriPart3Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
