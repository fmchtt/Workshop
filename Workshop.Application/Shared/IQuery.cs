using MediatR;

namespace Workshop.Application.Shared;

public interface IQuery<T> : IRequest<T>
{
}
