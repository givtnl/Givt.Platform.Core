using Givt.Core.Domain.Entities.Base;
using Givt.Core.Domain.Enums;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities;

public class AppVersion : EntityBase, IEntity
{
    public int BuildNumber { get; set; }
    public DeviceOS OperatingSystem { get; set; }
    public bool IsCritical { get; set; }
}