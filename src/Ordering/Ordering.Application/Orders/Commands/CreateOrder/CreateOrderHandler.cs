using BuildingBlocks.CQRS;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Domain.Models;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext)
: ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(command.Order); 

        await dbContext.AddOrderAsync(order);

        await dbContext.SaveChangesAsync(cancellationToken);

       return new CreateOrderResult(order);
    }
    private Order CreateNewOrder(OrderDto orderDto)
    {
        var newOrder = Order.Create(
            customerName: orderDto.CustomerName,
            totalAmount:  orderDto.TotalAmount,
            orderDate: orderDto.OrderDate
        );

        return newOrder;
    }
}
