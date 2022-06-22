using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class CreditCardConfiguration : EntityBaseConfiguration<CreditCard>
{
    public override void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        //base.Configure(builder); 

        builder
            .Property(e => e.Last4)
            .HasMaxLength(4);

        builder
            .Property(e => e.Fingerprint)
            .HasMaxLength(100);

    }
}
