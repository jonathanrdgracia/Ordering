namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrdenCommandHandler(IApplicationDbContext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderToUpdate = command.Order;
                var order = await dbContext.GetOrderByIdAsync(orderToUpdate.Id);
               
                await dbContext.UpdateOrderAsync(orderToUpdate);
                await dbContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception message )
            {
               throw new OrderNotFoundException(message.ToString());
            }
            return new UpdateOrderResult(true);
        }
    }
}
