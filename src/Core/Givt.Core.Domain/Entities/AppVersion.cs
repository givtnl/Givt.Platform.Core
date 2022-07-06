using Givt.Core.Domain.Enums;
using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class AppVersion : EntityBase, IEntity
{
    public int BuildNumber { get; set; }
    public DeviceOS OperatingSystem { get; set; }
    public bool IsCritical { get; set; }
}