using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Service;

public class Work : Entity
{
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Guid OwnerId { get; set; }
    public virtual Company Owner { get; set; } = null!;

    public Work()
    {
    }

    public Work(string? description, Guid ownerId, Company owner)
    {
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        Description = description;
        OwnerId = ownerId;
        Owner = owner;
    }
}
