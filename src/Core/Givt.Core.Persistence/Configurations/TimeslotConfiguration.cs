using Givt.Core.Domain.Entities;
using Givt.Platform.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class TimeslotConfiguration : EntityBaseConfiguration<Timeslot>
{
    public override void Configure(EntityTypeBuilder<Timeslot> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(e => e.Campaign)
            .WithMany(c => c.Timeslots)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade)
            ;

        builder
            .HasOne(e => e.Owner)
            .WithMany(o => o.Timeslots)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.Cascade)
            ;
    }
}
