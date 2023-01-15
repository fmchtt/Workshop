namespace Workshop.Domain.Entities
{
    public class Employee : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public Role Role { get; set; }
    }
}
