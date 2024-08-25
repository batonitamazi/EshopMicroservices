
using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand: ICommand<Unit> //empty icommand that does not return any response
    {
    }
    public interface ICommand<out TResponse> : IRequest<TResponse> //icommand that returns a generic response
    {
    }
}
