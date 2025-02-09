namespace Ordering.Domain.Events;

public record OrderUpdatedvent(Order order) : IDomainEvent;
