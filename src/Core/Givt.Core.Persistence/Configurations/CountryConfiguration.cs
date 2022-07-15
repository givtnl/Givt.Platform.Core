using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasKey(e => e.Code);

        builder
            .Property(e => e.Code)
            .HasMaxLength(2);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .HasOne(e => e.GivtOffice)
            .WithMany();

        builder.Property(x => x.PaymentMethods)
            .HasColumnType("BIGINT UNSIGNED")
            .HasConversion(PaymentMethodsConverter.GetConverter())
            .Metadata.SetValueComparer(PaymentMethodsConverter.GetComparer());
    }
}
