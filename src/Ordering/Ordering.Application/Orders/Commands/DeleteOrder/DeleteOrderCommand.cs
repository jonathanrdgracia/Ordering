
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(OrderDto Order):ICommand<DeleteOrderResult>;
public record DeleteOrderResult(bool isSuccess);

public class DeleteOrderCommandValidator: AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Order.OrderDate).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.TotalAmount).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Order.Status).NotNull().WithMessage("CustomerId is required");
    }
}