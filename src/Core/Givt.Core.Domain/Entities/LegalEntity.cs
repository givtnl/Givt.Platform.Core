﻿using Givt.Core.Domain.Entities.Base;
using Givt.Core.Domain.Enums;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities;

public class LegalEntity : EntityLockAudit<DateTime>, IEntity, IAuditBasic, IOptimisticLock<DateTime>
{
    public LegalEntityType Type { get; set; }
    public string FirstName { get; set; }
    public string Preposition { get; set; } // tussenvoegsel
    public string Name { get; set; }
    public string[] Address { get; set; }
    //public string AddressLine1 { get; set; }
    //public string AddressLine2 { get; set; }
    //public string AddressLine3 { get; set; }
    //public string AddressLine4 { get; set; }
    //public string AddressLine5 { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string CountryId { get; set; }
    public Country Country { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Url { get; set; }
}