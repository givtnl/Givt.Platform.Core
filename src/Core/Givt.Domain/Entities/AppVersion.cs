using Givt.Domain.Entities.Base;
using Givt.Domain.Enums;

namespace Givt.Domain.Entities;

public class AppVersion : EntityBase<Int64>
{
    public int BuildNumber { get; set; }
    public DeviceOS OperatingSystem { get; set; }
    public bool IsCritical { get; set; }
}