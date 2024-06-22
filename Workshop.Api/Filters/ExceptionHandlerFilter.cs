using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Workshop.Application.Results;
using Workshop.Domain.Exceptions;

namespace Workshop.Api.Filters;

public class ExceptionHandlerFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _handlers;

    public ExceptionHandlerFilter()
    {
        _handlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(AuthorizationException), HandlePermissionException }
        };
    }

    public override void OnException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (_handlers.ContainsKey(type))
        {
            _handlers[type].Invoke(context);
            return;
        }

        base.OnException(context);
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = (ValidationException)context.Exception;

        if (exception?.Errors?.Count > 0)
        {
            context.Result = new BadRequestObjectResult(exception.Errors);
        }
        else
        {
            context.Result = new BadRequestObjectResult(new MessageResult(exception?.Message ?? ""));
        }
        context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundException)context.Exception;

        context.Result = new NotFoundObjectResult(new MessageResult(exception.Message));
        context.ExceptionHandled = true;
    }

    private void HandlePermissionException(ExceptionContext context)
    {
        var exception = (AuthorizationException)context.Exception;

        context.Result = new UnauthorizedObjectResult(new MessageResult(exception.Message));
        context.ExceptionHandled = true;
    }
}
