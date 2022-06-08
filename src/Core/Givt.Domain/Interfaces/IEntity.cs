namespace Givt.Domain.Interfaces
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
