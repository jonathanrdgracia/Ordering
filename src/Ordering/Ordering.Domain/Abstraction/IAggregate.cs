namespace Ordering.Domain.Abstraction
{
    interface IAggregate<T>: IAggregate, IEntity<T>
    {

    }
     interface IAggregate:  IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvent {  get; }
        IDomainEvent[] clearDomainEvents();
    }
}
