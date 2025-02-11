
using Ordering.Application.Orders.Commands.DeleteOrder;

namespace Ordering.API.Endpoints
{
    public record DeleteOrderRequest(int Id);
    public record DeleteOrderResponse(bool response);
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/orders/{Id}", async (int Id, ISender sender) =>
            {
                var result = await sender.Send( new DeleteOrderCommand(Id));

                var respose = result.Adapt<DeleteOrderCommand>();


            });
        }
    }
}
