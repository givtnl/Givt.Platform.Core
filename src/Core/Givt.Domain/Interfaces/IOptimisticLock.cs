namespace Givt.Domain.Interfaces;

public interface IOptimisticLock<Ttoken>: IAuditBasic
{
    Ttoken ConcurrencyToken { get; set; }
}
