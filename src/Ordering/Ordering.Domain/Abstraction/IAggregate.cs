using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
