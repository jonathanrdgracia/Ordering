using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos
{
        public record OrderDto(
            int Id,
            string CustomerName,
            decimal TotalAmount,
            OrderStatus Status,
            DateTime OrderDate
         );
}
