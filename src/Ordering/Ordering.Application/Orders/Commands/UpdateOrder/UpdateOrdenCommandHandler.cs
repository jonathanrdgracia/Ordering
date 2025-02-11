namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrdenCommandHandler(IApplicationDbContext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var _orderToUpdate = command.Order;
                var order = await dbContext.GetOrderByIdAsync(_orderToUpdate.Id);
               
                await dbContext.UpdateOrderAsync(_orderToUpdate);

            }
            catch (Exception message )
            {
                return new UpdateOrderResult(false);
            }
            return new UpdateOrderResult(true);
        }
    }
}
