using Correios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MultiTracking.Data.Mapping
{
    public class PackageMap : IEntityTypeConfiguration<PackageEntity>
    {
        public void Configure(EntityTypeBuilder<PackageEntity> builder)
        {
            builder.ToTable("Package");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(u => u.Code).HasColumnName("Code").IsRequired().HasMaxLength(20);

            //builder.HasMany(p => p.Meetings)
            //    .WithMany(p => p.Users)
            //    .UsingEntity<MeetingUser>(
            //        p => p.HasOne(p => p.Meeting).WithMany().HasForeignKey(x => x.MeetingsId),
            //        p => p.HasOne(p => p.User).WithMany().HasForeignKey(x => x.UsersId));
        }
    }
}
