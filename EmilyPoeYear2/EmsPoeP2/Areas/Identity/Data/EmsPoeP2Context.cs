using EmsPoeP2.Areas.Identity.Data;
using EmsPoeP2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmsPoeP2.Data;

public class EmsPoeP2Context : IdentityDbContext<IdentityUser>
{
    public EmsPoeP2Context(DbContextOptions<EmsPoeP2Context> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

public DbSet<EmsPoeP2.Models.Product> Product { get; set; } = default!;
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SampleUsers>
{
 

    public void Configure(EntityTypeBuilder<SampleUsers> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
    }
}