using EmsFinalPoe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmsFinalPoe.Data;

public class EmsFinalPoeContext : IdentityDbContext<IdentityUser>
{
    public EmsFinalPoeContext(DbContextOptions<EmsFinalPoeContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Farmer>
{
    public void Configure(EntityTypeBuilder<Farmer> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);


    }
}