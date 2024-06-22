using FluentValidation;
using MediatR;
using Workshop.Application.Shared;

namespace Workshop.Infra.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            throw new Domain.Exceptions.ValidationException(
                "Comando inválido",
                validation.Errors.Select(error => new Domain.Exceptions.ValidationError(error.PropertyName, error.ErrorMessage)).ToList()
            );
        }

        return await next();
    }
}
