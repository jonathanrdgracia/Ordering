
using Ordering.Domain.Abstraction;

namespace Ordering.Domain.Models
{
    public class Order: Aggregate<Guid>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Guid CustomerID { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public decimal TotalAmount { get; set; } = default!;

    }
}
