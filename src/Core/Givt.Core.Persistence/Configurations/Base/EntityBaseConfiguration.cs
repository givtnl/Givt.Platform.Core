using Givt.Core.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations.Base
{
    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
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
