
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(int Id):ICommand<DeleteOrderResult>;
public record DeleteOrderResult(bool isSuccess);

public class DeleteOrderCommandValidator: AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
       RuleFor(x=>x.Id).NotEmpty().WithMessage("Id for delete Order is required");
    }
}