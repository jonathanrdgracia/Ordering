

using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;
using Ordering.Domain.Models;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
  public record CreateOrderCommand(OrderDto Order)
    : ICommand<CreateOrderResult>;
 
   public record CreateOrderResult(Order order);

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Order.CustomerName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Order.TotalAmount).NotNull().WithMessage("TotalAmount should not empty");
        } 
    }
}
