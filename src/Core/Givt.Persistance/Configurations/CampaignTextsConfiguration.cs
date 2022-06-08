using Givt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class CampaignTextsConfiguration : IEntityTypeConfiguration<CampaignTexts>
{
    public void Configure(EntityTypeBuilder<CampaignTexts> builder)
    {
        builder
            .HasKey(e => new { e.CampaignId, e.LanguageId });

        builder
            .Property(e => e.LanguageId)
            .HasMaxLength(18); // longest known: "es-Ca-valencia" = 14
        builder
            .Property(e => e.Title)
            .HasMaxLength(175);
        builder
            .Property(e => e.Goal)
            .HasMaxLength(400);
        builder
            .Property(e => e.ThankYou)
            .HasMaxLength(400);

        builder
            .HasOne(e => e.Campaign)
            .WithMany(c => c.Texts)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasKey(x => new { x.CampaignId, x.LanguageId });

    }
}
