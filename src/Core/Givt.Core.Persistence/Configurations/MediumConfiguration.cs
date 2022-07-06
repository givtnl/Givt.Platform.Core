using Givt.Core.Domain.Entities;
using Givt.Platform.EF.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class MediumConfiguration : EntityBaseConfiguration<Medium>
{
    public override void Configure(EntityTypeBuilder<Medium> builder)
    {
        base.Configure(builder);

        // configure Table per Hierarchy strategy
        builder
            .HasDiscriminator<int>("Class")
            .HasValue<Medium>(1)
            .HasValue<Location>(2);

        builder
           .Property(e => e.MediumId)
           .HasMaxLength(33);

        builder
            .HasOne(x => x.Owner)
            .WithMany(x => x.Mediums)
            .HasForeignKey(x => x.OwnerId);

        builder
           .HasOne(e => e.Campaign)
           .WithMany(m => m.Mediums)
           //.OnDelete(DeleteBehavior.Restrict)
           ;

    }
}
