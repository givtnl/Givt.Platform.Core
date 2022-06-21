using AutoMapper;
using Givt.Domain.Entities;
using Givt.Domain.Enums;
using Givt.Domain.Mappings;
using Givt.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Givt.Persistence.Test
{
    public class LegalEntityTests
    {
        private readonly DbContextOptions<GivtDbContext> dbContextOptions =
            new DbContextOptionsBuilder<GivtDbContext>()
            .UseInMemoryDatabase(databaseName: "givt_platform_test")
            .Options;

        private readonly IMapper mapper =
            new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>
                {
                    new DonationHistoryMappingProfile(),
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
            using (var context = new GivtDbContext(dbContextOptions, mapper))
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
            using (var contextA = new GivtDbContext(dbContextOptions, mapper))
            using (var contextB = new GivtDbContext(dbContextOptions, mapper))
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