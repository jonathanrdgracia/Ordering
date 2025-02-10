
using Ordering.Application.Orders.Queries.GetOrderById;

namespace Ordering.API.Endpoints
{
    public class GetOrderById : ICarterModule
    {
       public record GetOrderByIdResponse(OrderDto Order);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/order/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetOrderByIdQuery(id));

                var reponse = result.Adapt<GetOrderByIdResponse>();

                return Results.Ok(reponse);

            });
           
        }
    }
}
