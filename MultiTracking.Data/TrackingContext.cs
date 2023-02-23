using Correios.App.Models;
using Microsoft.EntityFrameworkCore;
using MultiTracking.Data.Mapping;

namespace MultiTracking.Data
{
    public class TrackingContext : DbContext
    {
        public DbSet<PackageEntity> Packages { get; set; }

        public TrackingContext(DbContextOptions<TrackingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PackageEntity>(new PackageMap().Configure);
        }
    }
}
