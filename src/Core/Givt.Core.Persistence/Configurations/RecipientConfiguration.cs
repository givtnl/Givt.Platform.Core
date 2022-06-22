using Givt.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
{
    public void Configure(EntityTypeBuilder<Recipient> builder)
    {
        builder
            .HasKey(e => e.OwnerId);

        builder
            .Property(e => e.DisplayName)
            .HasMaxLength(175);

        builder.Property(x => x.LogoImageLink)
            .HasMaxLength(200);


        builder
            .HasOne(e => e.Owner)
            .WithOne()
            .IsRequired(true);

        builder
            .HasOne(e => e.PrimaryPayOutMethod)
            .WithMany()
            .HasForeignKey(e => e.PrimaryPayOutMethodId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(r => r.Campaigns)
            .WithOne(c => c.Owner)
            .IsRequired(true)
            .HasForeignKey(c => c.OwnerId);

        builder
            .HasOne(e => e.PrimaryPayOutMethod)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
