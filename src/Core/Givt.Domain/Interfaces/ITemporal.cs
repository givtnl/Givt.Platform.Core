using System;

namespace Givt.Domain.Interfaces;

public interface ITemporal
{
    DateTime? DateFrom { get; set; }
    DateTime? DateTo { get; set; }
}
