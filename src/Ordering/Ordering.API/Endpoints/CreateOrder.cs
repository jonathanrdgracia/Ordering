using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints
{
        public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponde(Guid Id);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/orders", async (CreateOrderRequest request, ISender sender) =>
            {
                try
                {
                    var command = request.Adapt<CreateOrderCommand>();
                    await sender.Send(command);

                    return Results.StatusCode(StatusCodes.Status201Created);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return Results.Problem(
                        title: "Validation Error",
                        detail: ex.Message,
                        statusCode: StatusCodes.Status400BadRequest);
                }
            })
            .WithName("CreateOrder")
            .Produces<CreateOrderResponde>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
        }
    }
}
