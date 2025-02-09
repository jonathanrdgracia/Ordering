namespace Ordering.Domain.Abstraction
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
