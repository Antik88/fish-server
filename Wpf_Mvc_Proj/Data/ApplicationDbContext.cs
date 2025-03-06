using Microsoft.EntityFrameworkCore;
using Wpf_Mvc_Proj.Models;

namespace ApplicationDbContextNs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EnvironmentalQuality> EnvironmentalQualities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EnvironmentalQuality Configuration
            modelBuilder.Entity<EnvironmentalQuality>(entity =>
            {
                entity.HasKey(e => e.QualityId);
                entity.Property(e => e.PollutionLevel).HasMaxLength(50);

            });

            // Product Configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).HasMaxLength(255);

            });

            // SalesPoint Configuration
            modelBuilder.Entity<SalesPoint>(entity =>
            {
                entity.HasKey(sp => sp.SalesPointId);
                entity.Property(sp => sp.Name).HasMaxLength(255);
                entity.Property(sp => sp.Address).HasMaxLength(255);
                entity.Property(sp => sp.WorkingHours).HasMaxLength(255);

            });

            // Region Configuration
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(r => r.RegionId);
                entity.Property(r => r.Name).HasMaxLength(255);
                entity.Property(r => r.Area).HasMaxLength(255);
                entity.Property(r => r.City).HasMaxLength(255);

            });
        }
    }
}