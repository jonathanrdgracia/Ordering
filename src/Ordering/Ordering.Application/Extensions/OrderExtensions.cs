
using Ordering.Application.Dtos;

namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDTOList(this IEnumerable<OrderDto> orders)
        {
            return orders.Select(order => new OrderDto(
                Id: order.Id,
               CustomerName: order.CustomerName,
               TotalAmount: order.TotalAmount,
               OrderDate: order.OrderDate,
               Status: order.Status
           ));

        }

    }
}
