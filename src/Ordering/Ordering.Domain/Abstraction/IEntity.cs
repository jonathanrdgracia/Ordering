namespace Ordering.Domain.Abstraction
{

    public interface IEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
    public interface IEntity
    {
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount  { get; set; }
        public OrderStatus Status { get; set; }
    }
}
