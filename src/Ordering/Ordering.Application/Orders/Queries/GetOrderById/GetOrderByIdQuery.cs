using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(int Id): IQuery<GetOrderByIdResult>;

public record GetOrderByIdResult(OrderDto Order);
