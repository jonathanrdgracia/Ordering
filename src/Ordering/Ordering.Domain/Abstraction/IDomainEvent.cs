using MediatR;

namespace Ordering.Domain.Abstraction
{
    public interface IDomainEvent: INotification
    {
        Guid Guid => Guid.NewGuid();
        public DateTime Occurreon => DateTime.Now;

        public string EventType => GetType().AssemblyQualifiedName!;

    }
}
