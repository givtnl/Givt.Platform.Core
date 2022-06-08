using Givt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder
            .HasKey(e => e.OwnerId);

        builder
            .Property(e => e.Language)
            .HasMaxLength(18);
        builder
            .Property(e => e.TimeZoneId)
            .HasMaxLength(15);

        builder
            .HasOne(e => e.Owner)
            .WithOne()
            .IsRequired(true);

        builder
            .HasOne(e => e.PrimaryPayInMethod)
            .WithMany()
            .HasForeignKey(e => e.PrimaryPayInMethodId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
