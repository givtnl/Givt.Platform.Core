using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

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
            //.OnDelete(DeleteBehavior.Cascade)
            ;
    }
}
