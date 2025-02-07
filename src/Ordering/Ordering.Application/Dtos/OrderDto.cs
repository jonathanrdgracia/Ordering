namespace Ordering.Application.Dtos
{
    public class OrderDto
    {
        public Guid CustomerID { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public decimal TotalAmount { get; set; } = default!;
    }
}
