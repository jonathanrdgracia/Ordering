
using Mapster;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.Application.Orders.Queries.GetOrder;
public class GetOrderHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        
        var orders = await dbContext.GetOrdersAsync();
        var orderList = orders.Adapt<List<OrderDto>>();

        var orderDtos = ProjecToOrderDto(orderList);

        return new GetOrdersResult(orderDtos.ToOrderDTOList());
    }

    private List<OrderDto> ProjecToOrderDto(List<OrderDto> orders)
    {
        List<OrderDto> result = new();

        foreach (var order in orders) 
        {
            var orderDto = new OrderDto(
            
                Id: order.Id,
                CustomerName: order.CustomerName,
                TotalAmount: order.TotalAmount,
                OrderDate: order.OrderDate,
                Status: order.Status
                
            );
            result.Add( orderDto );
        }
        return result.ToList();
    }
}
