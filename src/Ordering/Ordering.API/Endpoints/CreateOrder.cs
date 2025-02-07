using Ordering.Application.Dtos;

namespace Ordering.API.Endpoints
{
    public class CreateOrder
    {
        public record CreateOrderRquest(OrderDto order);

    }
}
