using static Ordering.Domain.Abstraction.IEntity;

namespace Ordering.Domain.Abstraction
{

    interface IEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
    interface IEntity
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount  { get; set; }
    }
}
