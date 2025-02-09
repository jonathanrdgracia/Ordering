using Ordering.Domain.ValueObject;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public string CustomerName { get; set; } = default!;
        public decimal TotalAmount { get; set; } = default!;
        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public static Order Create(OrderId id, decimal totalAmount, string customerName)
        {
            var order = new Order
            {
                Id = id,
                CustomerName = customerName,
                TotalAmount = totalAmount,
            };

            order.AddDomainEvent(new OrderCreatedEvent(order));
            return order;

        }

        public void Update(decimal totalAmount, string customerName)
        {
            CustomerName = customerName;
            TotalAmount = totalAmount;

            AddDomainEvent(new OrderUpdatedvent(this));
        }
        public void Delete(OrderId orderId)
        {
            Status = OrderStatus.Deleted;

            AddDomainEvent(new OrderDeletedEvent(this));
        }

        public void Add(decimal totalAmount, string customerName)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(totalAmount);
            ArgumentOutOfRangeException.ThrowIfLessThan(customerName.Length,5);



        }

    }
}