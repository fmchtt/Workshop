using MediatR;

namespace Workshop.Application.Shared;

public interface ICommand<T> : IRequest<T>
{
}
