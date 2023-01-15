namespace Workshop.Domain.Entities
{
    public class Order : Entity
    {
        public int OrderNumber { get; set; }

        public List<Item> items { get; set; }

        public int Total { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
