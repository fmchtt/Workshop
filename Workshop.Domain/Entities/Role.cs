namespace Workshop.Domain.Entities
{
    public class Role : Entity
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public List<Permission> Permissions { get; set; }

    }
}
