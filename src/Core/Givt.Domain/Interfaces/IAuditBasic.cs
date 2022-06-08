namespace Givt.Domain.Interfaces;

public interface IAuditBasic
{
    DateTime Created { get; set; }
    DateTime Modified { get; set; }
}