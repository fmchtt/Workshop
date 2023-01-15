using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.DTO.Results;

public class SuccessResultDTO : GenericResultDTO
{
    public SuccessResultDTO(string message, object result) : base(message, result)
    {
    }
}
