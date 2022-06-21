using Givt.Domain.Entities.Base;
using Givt.Domain.Enums;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public class AppVersion : EntityBase, IEntity
{
    public int BuildNumber { get; set; }
    public DeviceOS OperatingSystem { get; set; }
    public bool IsCritical { get; set; }
}