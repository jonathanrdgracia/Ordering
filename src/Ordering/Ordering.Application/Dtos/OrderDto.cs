﻿namespace Ordering.Application.Dtos
{
        public record OrderDto(
         Guid Id,
         Guid CustomerId ,
         string CustomerName,
         decimal TotalAmount
         );
}
