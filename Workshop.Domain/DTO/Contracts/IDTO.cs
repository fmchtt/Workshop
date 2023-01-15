using Flunt.Validations;

namespace Workshop.Domain.DTO.Contracts;

internal interface IDTO : IValidatable
{
    void Validate();
}
