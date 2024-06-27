using MediatR;
using Workshop.Application.Shared;
using Workshop.Domain.Utils;

namespace Workshop.Application.Behavior;

public class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransaction(cancellationToken);

        try
        {
            var response = await next();
            await unitOfWork.Commit(cancellationToken);
            return response;
        }
        catch (Exception)
        {
            await unitOfWork.Rollback(cancellationToken);
            throw;
        }
    }
}
