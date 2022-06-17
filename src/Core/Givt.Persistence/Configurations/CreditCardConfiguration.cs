using Givt.Domain.Entities;
using Givt.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

public class CreditCardConfiguration : EntityBaseInt64Configuration<CreditCard>
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
