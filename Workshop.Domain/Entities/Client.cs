namespace Workshop.Domain.Entities;

public class Client : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Order> Orders { get; set; }
    public List<Company> ReceivingServices { get; set; }

    public Client(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public Client(string name) {
        Name = name;
    }
}
