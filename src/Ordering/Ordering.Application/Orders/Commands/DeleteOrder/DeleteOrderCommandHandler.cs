
using BuildingBlocks.CQRS;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObject;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IApplicationDbContext dbContext)
         : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var _id = command.Id;
                await dbContext.DeleteOrderAsync(_id);
                return new DeleteOrderResult(true); 
            }
            catch (Exception)
            {
                throw new OrderNotFoundException(command.Id.ToString());
            }
        }
    }
}