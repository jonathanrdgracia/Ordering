namespace Ordering.Domain.Abstraction
{
    public abstract class Aggregate<TID> : Entity<TID>, IAggregate<TID>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvent => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IDomainEvent[] clearDomainEvents()
        {
            IDomainEvent[] dequeueEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeueEvents;
        }
    }
}
