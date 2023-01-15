using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.DTO.Results;

public abstract class GenericResultDTO
{
    public string Message { get; set; }
    public object Result { get; set; }

    public GenericResultDTO(string message) {
        Message = message;
    }

    public GenericResultDTO(string message, object result)
    {
        Message = message;
        Result = result;
    }
}
