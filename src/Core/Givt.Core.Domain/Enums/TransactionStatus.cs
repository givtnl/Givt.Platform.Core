namespace Givt.Core.Domain.Enums;

public enum TransactionStatus
{
    All = 0,
    Entered = 1,
    ToProcess = 2,
    Processed = 3,
    Rejected = 4,
    Cancelled = 5,
}