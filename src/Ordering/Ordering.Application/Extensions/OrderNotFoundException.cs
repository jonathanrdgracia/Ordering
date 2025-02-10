using BuildingBlocks.Exceptions;

namespace Ordering.Application.Extensions;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(string message) : base(message)
    {
    }
}