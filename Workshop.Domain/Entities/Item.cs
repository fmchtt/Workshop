namespace Workshop.Domain.Entities
{
    public class Item : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Price { get; set; }

        public int OwnerId { get; set; }

        public Company Owner { get; set; }
    }
}
