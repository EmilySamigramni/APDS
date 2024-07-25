using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Farmer>()
            .HasKey(f => f.FarmerID);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductID);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Farmer)
            .WithMany(f => f.Products)
            .HasForeignKey(p => p.FarmerID);

        base.OnModelCreating(modelBuilder);
    }
}
