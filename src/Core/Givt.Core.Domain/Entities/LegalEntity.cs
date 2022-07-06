using Givt.Core.Domain.Enums;
using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class LegalEntity : EntityLockAudit<DateTime>, IEntity, IAuditBasic, IOptimisticLock<DateTime>
{
    public LegalEntityType Type { get; set; }
    public string FirstName { get; set; }
    public string Preposition { get; set; } // tussenvoegsel
    public string Name { get; set; }
    public string[] Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string CountryId { get; set; }
    public Country Country { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Url { get; set; }
}