
using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IApplicationDbContext dbContext)
         : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}