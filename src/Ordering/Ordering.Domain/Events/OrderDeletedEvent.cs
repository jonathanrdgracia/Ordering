namespace Ordering.Domain.Events;

public record OrderDeletedEvent(Order order) : IDomainEvent;
