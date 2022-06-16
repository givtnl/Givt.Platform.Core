using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;

namespace Givt.Persistance.DbContexts
{
    public class CockroachMigrationsSqlGenerator : NpgsqlMigrationsSqlGenerator
    {
        public CockroachMigrationsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
#pragma warning disable EF1001 // Internal EF Core API usage.
            INpgsqlOptions npgsqlOptions)
#pragma warning restore EF1001 // Internal EF Core API usage.
            : base(dependencies, npgsqlOptions)
        {
        }

        protected override void DefaultValue(object defaultValue, string defaultValueSql, string columnType, MigrationCommandListBuilder builder)
        {
            const string ON_UPDATE_MARKER = "ON UPDATE";
            //Check.NotNull(builder, nameof(builder));

            if (defaultValueSql != null)
            {
                var p = defaultValueSql.IndexOf(ON_UPDATE_MARKER);
                if (p > 0)
                {                    
                    builder
                        .Append(" DEFAULT (")
                        .Append(defaultValueSql[..p].Trim())
                        .Append(")");
                    builder
                        .Append(" ON UPDATE (")
                        .Append(defaultValueSql[(p + ON_UPDATE_MARKER.Length)..].Trim())
                        .Append(")");
                    return;
                }
            }
            base.DefaultValue(defaultValue, defaultValueSql, columnType, builder);
        }
    }
}