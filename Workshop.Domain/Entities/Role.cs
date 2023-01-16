namespace Workshop.Domain.Entities
{
    public class Role : Entity
    {
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public List<Permission> Permissions { get; set; }

        public Role(Guid companyId, List<Permission> permissions)
        {
            CompanyId = companyId;
            Permissions = permissions;
        }

    }
}
