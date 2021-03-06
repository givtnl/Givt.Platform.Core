using Givt.Core.Domain.Entities;
using Givt.Platform.EF.Configurations;
using Givt.Core.Persistence.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class LegalEntityConfiguration : OptimisticLockConfiguration<LegalEntity>
{
    public override void Configure(EntityTypeBuilder<LegalEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.FirstName)
            .HasMaxLength(50);
        builder
            .Property(e => e.Preposition)
            .HasMaxLength(50);
        builder
            .Property(e => e.Name)
            .HasMaxLength(100);
        builder
            .Property(e => e.Address)
            .HasConversion(StringArrayConverter.GetConverter())
            .HasMaxLength(500)
            .Metadata.SetValueComparer(StringArrayConverter.GetComparer());

        builder
            .Property(e => e.PostalCode)
            .HasMaxLength(50);
        builder
            .Property(e => e.City)
            .HasMaxLength(50);
        builder
            .Property(e => e.CountryId)
            .HasMaxLength(2);
        builder
            .HasOne(e => e.Country)
            .WithMany()
            .HasForeignKey(e => e.CountryId);
        builder
            .Property(e => e.PhoneNumber)
            .HasMaxLength(175);
        builder
            .Property(e => e.EmailAddress)
            .HasMaxLength(175);
        builder
            .Property(e => e.Url)
            .HasMaxLength(175);
    }
}
