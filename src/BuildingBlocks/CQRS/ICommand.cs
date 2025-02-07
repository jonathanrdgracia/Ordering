using MediatR;

namespace BuildingBlocks.CQRS
{
    interface ICommand: ICommand<Unit>
    {

    }
    interface ICommand<out TResponse>: IRequest<TResponse>
    {

    }
}
