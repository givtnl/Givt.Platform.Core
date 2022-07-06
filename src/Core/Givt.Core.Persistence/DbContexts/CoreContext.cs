using AutoMapper;
using Givt.Core.Domain.Entities;
using Givt.Platform.EF.DbContexts;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.Http.Logger;

namespace Givt.Core.Persistence.DbContexts;

public class CoreContext : CommonContext
{
    private readonly IMapper _mapper;
    private readonly ILog _log;

    public CoreContext(
        DbContextOptions options, 
        IMapper mapper,
        ILog logger)
        : base(options, mapper)
    {
        _mapper = mapper;
        _log = logger;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Authorisation> Authorisations { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<LegalEntity> LegalEntities { get; set; }
    public DbSet<Recipient> Recipients { get; set; }
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Medium> Mediums { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Timeslot> Timeslots { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Fee> Fees { get; set; }
    public DbSet<FeeAgreement> FeeAgreements { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}
