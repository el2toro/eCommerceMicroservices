namespace Ordering.Domain.Abstractions;

public interface IAgregate<T> : IAgregate, IEntity<T>
{

}

public interface IAgregate
{
    IReadOnlyList<IDomainEvent> DomainEvent { get; }
    IDomainEvent[] ClearDomainIvents();
}
