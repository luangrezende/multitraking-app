using AngleSharp;
using Correios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTracking.Data.Mapping;

namespace MultiTracking.Data
{
    public class TrackingContext : DbContext
    {
        public DbSet<PackageEntity> Packages { get; set; }

        public TrackingContext()
        {
        }

        public TrackingContext(DbContextOptions<TrackingContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
        //    var config = configuration.Build();
        //    var connectionString = config.GetSection("ConnectionString").Value;

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PackageEntity>(new PackageMap().Configure);
        }
    }
}
