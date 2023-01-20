using Flunt.Validations;

namespace Workshop.Domain.DTO.Input.Contracts;

internal interface IDTO : IValidatable
{
    void Validate();
}
