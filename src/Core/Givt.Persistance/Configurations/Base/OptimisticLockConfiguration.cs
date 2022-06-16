﻿using Givt.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations.Base
{
    public class OptimisticLockConfiguration<TEntityAudit> : EntityBaseInt64Configuration<TEntityAudit>
        where TEntityAudit : EntityLockAudit<Int64, DateTime>
    {
        public override void Configure(EntityTypeBuilder<TEntityAudit> builder)
        {
            base.Configure(builder);
            // override property default settings
            // MariaDB
            //builder
            //    .Property(e => e.ConcurrencyToken)
            //    .IsRowVersion();
            // CockroachDB: ConcurrencyToken TIMESTAMPTZ DEFAULT now() ON UPDATE now().
            // Note: ON UPDATE on a Column is not standard SQL. Special support for migrations is needed.
            builder
                .Property(e => e.ConcurrencyToken)
                .HasDefaultValueSql("now() ON UPDATE now()")
                .IsConcurrencyToken();
        }
    }

}

