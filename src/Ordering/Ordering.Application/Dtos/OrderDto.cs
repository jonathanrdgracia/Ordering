using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos
{
        public record OrderDto(
         Guid Id,
         Guid CustomerId ,
         string CustomerName,
         OrderStatus OrderStatus,
         decimal TotalAmount
         );
}
