using FinalYearPoePart3.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalYearPoePart3.Areas.Identity.Data;

public class FinalYearPoePart3Context : IdentityDbContext<FarmerUser>
{
    public FinalYearPoePart3Context(DbContextOptions<FinalYearPoePart3Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<FarmerUser>
{
    public void Configure(EntityTypeBuilder<FarmerUser> builder)
    {
builder.Property(x => x.FirstName).HasMaxLength(100);
builder.Property(x => x.LastName).HasMaxLength(100);


    }
}
