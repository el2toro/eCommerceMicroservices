
namespace Ordering.Domain.Abstractions;

public abstract class Agregate<TId> : Entity<TId>, IAgregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvent => _domainEvents.AsReadOnly();

    public void AddDomainEvents(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public IDomainEvent[] ClearDomainIvents()
    {
        IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();

        return dequeuedEvents;
    }
}
