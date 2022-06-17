using Givt.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations.Base
{
    public class EntityBaseInt64Configuration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<Int64>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            //CockroachDB
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("unique_rowid()");
        }
    }
}
