using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery()
    : IQuery<GetOrdersResult>;

    public record GetOrdersResult(IEnumerable<OrderDto> orders);
}
