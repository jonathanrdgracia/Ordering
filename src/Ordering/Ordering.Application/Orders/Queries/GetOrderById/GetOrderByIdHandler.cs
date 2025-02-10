

using Mapster;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdHandler(IApplicationDbContext dbContext)

        : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {

            var order = await dbContext.GetOrderByIdAsync(query.Id);

            var response = order.Adapt<OrderDto>();

            // Devolver el resultado esperado
            return new GetOrderByIdResult(response);

        }
    }
}
