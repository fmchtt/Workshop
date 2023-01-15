namespace Workshop.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

    }
}
