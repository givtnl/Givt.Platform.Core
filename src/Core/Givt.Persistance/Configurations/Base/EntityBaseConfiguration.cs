using Givt.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations.Base
{
    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("(UUID())")
                .HasColumnType("BINARY(16)")
                .IsRequired();
        }
    }
}
