using BuildingBlocks.CQRS;
using Ordering.Application.Data;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext)
: ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public  Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //create order entity from command object
        //save to database
        //return result
        //var order = CreateNewOrder(command.Order);
        //dbContext.Order
        throw new NotImplementedException();
    }
}
