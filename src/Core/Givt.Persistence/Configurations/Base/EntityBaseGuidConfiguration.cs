using Givt.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations.Base
{
    public class EntityBaseGuidConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
            // MariaDB:
            //    .HasDefaultValueSql("UUID()")
            //    .HasColumnType(Consts.GUID_COLUMN_TYPE)
            // CockroachDB
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();
        }
    }
}
