using AutoMapper;
using Givt.Core.Domain.Entities;
using Givt.Core.Domain.Enums;
using Givt.Core.Persistence.DbContexts;
using Givt.Platform.Common.Loggers;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.Http.Logger;

namespace Givt.Core.Persistence.Test
{
    public class LegalEntityTests
    {
        private readonly DbContextOptions<CoreContext> dbContextOptions =
            new DbContextOptionsBuilder<CoreContext>()
            .UseInMemoryDatabase(databaseName: "givt_platform_test")
            .Options;

        private readonly IMapper mapper =
            new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>
                {
                });
            })
            .CreateMapper();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task LegalEntity_OptimisticLock()
        {
            // save legal entity
            Guid id;
            // TODO: create proper mockup of ILog
            var logConfig = new LogitHttpLoggerOptions
            {
                Tag = "Test",
                Key = "Invalid"
            };
            ILog logger = new LogitHttpLogger(logConfig);
            using (var context = new CoreContext(dbContextOptions, mapper, logger))
            {
                var entity = new LegalEntity
                {
                    Type = LegalEntityType.Organisation,
                    FirstName = null,
                    Preposition = null,
                    Name = "Givt b.v.",
                    Address = new string[] { "Schutweg 47" },
                    PostalCode = null,
                    City = "Lelystad",
                    CountryId = null,
                    PhoneNumber = "+31 320 320 115",
                    EmailAddress = "support@givtapp.net",
                    Url = "www.givtapp.net"
                };
                context.Add(entity);
                await context.SaveChangesAsync();
                id = entity.Id;
            }
            using (var contextA = new CoreContext(dbContextOptions, mapper, logger))
            using (var contextB = new CoreContext(dbContextOptions, mapper, logger))
            {
                var entityA = contextA.LegalEntities
                    .Where(x => x.Id == id)
                    .First();
                var entityB = contextB.LegalEntities
                    .Where(x => x.Id == id)
                    .First();
                entityA.PostalCode = "8243 PC";
                entityB.PostalCode = "8243 PC";
                Assert.DoesNotThrow(() => contextA.SaveChanges());
                // This does not work
                // TODO: use real database, InMemory database probably has no or another mechanism for concurrency token?
                //Assert.Throws<DbUpdateConcurrencyException>(() => contextB.SaveChanges());
                contextA.Remove(entityA);
                Assert.DoesNotThrow(() => contextA.SaveChanges());
            }
        }
    }
}