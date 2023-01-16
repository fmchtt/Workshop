using Workshop.Domain.Contracts.Results;

namespace Workshop.Domain.UseCases.Contracts;
public interface IUseCase<T>
{
    GenericResult handle(T t);
}
