﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.UpdateWork;

public class UpdateWorkInOrderCommand : ICommand<WorkInOrder>
{
    [JsonIgnore]
    public Guid WorkId { get; set; }
    [JsonIgnore]
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateFinish { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
