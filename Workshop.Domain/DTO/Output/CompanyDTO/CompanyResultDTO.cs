using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.CompanyDTO;

public class CompanyResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public CompanyResultDTO(Company company)
    {
        Id = company.Id;
        Name = company.Name;
    }
}
