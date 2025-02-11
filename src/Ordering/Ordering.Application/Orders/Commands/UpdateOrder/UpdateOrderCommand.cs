using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

    public record  UpdateOrderCommand(OrderDto Order): ICommand<UpdateOrderResult>;
    public record UpdateOrderResult(bool isSucccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id for update Order is required");
        }
    }