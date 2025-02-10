
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{

    public class GetOrdersResponse : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/orders", async (ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery());

                return Results.Ok(result.orders);
            })
            .WithName("GetOrders")
            .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders"); ;
        }
    }
}
