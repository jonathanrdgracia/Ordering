using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstraction
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
