using Givt.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class GivtOfficeConfiguration : IEntityTypeConfiguration<GivtOffice>
{
    public void Configure(EntityTypeBuilder<GivtOffice> builder)
    {
        builder
            .HasKey(e => e.OwnerId);

        builder
            .Property(e => e.WantKnowMore)
            .HasMaxLength(175); 
        
        builder
            .Property(e => e.GivtPrivacyPolicy)
            .HasMaxLength(175);



        builder
            .HasOne(e => e.Owner)
            .WithOne()
            .IsRequired(true);

    }
}
