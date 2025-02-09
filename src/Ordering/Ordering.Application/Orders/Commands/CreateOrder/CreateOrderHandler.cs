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
        var order = CreateNewOrder(command.Order); //create order entity from command object
        //save to database
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

       return new CreateOrderResult(order.Id.Value);
    }

    //private Order CreateNewOrder(OrderDto order)
    //{
    //    var newOrder =  Order.Create (

    //        );
    //}
}
