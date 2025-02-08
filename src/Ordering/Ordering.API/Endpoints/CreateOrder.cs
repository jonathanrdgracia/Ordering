using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints
{
        public record CreateOrderRequest(OrderDto Order);
        public record CreateOrderResponde(Guid Id);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
            {
                var coomand = request.Adapt<CreateOrderCommand>();
                var result = await sender.Send(coomand);
                var response = result.Adapt<CreateOrderResponde>();
                
                return Results.CreatedAtRoute($"/orders/{response.Id}", response);

            })
                .WithName("CreateOrder")
                .Produces<CreateOrderResponde>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Order")
                .WithDescription("Create Order");
        }
    }
}
