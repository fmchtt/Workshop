using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Repositories.Core;

namespace Workshop.Application.Behavior;

public class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfOfWork) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }

        var response = await next();

        await unitOfOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }
}
