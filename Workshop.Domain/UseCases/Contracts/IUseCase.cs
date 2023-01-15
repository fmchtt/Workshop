using Workshop.Domain.DTO.Results;

namespace Workshop.Domain.UseCases.Contracts;
public interface IUseCase<T>
{
    GenericResultDTO handle(T t);
}
