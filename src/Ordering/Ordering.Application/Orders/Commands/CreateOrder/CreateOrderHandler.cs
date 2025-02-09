using BuildingBlocks.CQRS;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObject;


namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext)
: ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //create order entity from command object
        //save to database
        //return resutl

        var order = CreateNewOrder(command.Order); 
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

       return new CreateOrderResult(order);
    }
    //OrderId id, decimal totalAmount, string customerName
    private Order CreateNewOrder(OrderDto orderDto)
    {
        var newOrder = Order.Create(
            customerName: orderDto.CustomerName,
            totalAmount:  orderDto.TotalAmount
        );

        return newOrder;
    }
}
