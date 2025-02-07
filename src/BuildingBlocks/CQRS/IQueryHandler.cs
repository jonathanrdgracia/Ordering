using MediatR;

namespace BuildingBlocks.CQRS
{
    interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {


    }
}
