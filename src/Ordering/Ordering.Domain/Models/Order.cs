using Ordering.Domain.ValueObject;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = default!;
        public decimal TotalAmount { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Active;
        public static Order Create(string customerName, decimal totalAmount, DateTime orderDate)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(totalAmount.ToString().Length,0);
            ArgumentOutOfRangeException.ThrowIfLessThan(customerName.Length, 3);

            var order = new Order
            {
                CustomerName = customerName,
                TotalAmount = totalAmount,
                OrderDate = orderDate
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
            ArgumentOutOfRangeException.ThrowIfLessThan(customerName.Length, 5);
        }
    }
}