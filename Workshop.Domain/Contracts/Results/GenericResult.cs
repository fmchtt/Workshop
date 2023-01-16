using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.Contracts.Results;

public abstract class GenericResult
{
    public string Message { get; set; }
    public object Result { get; set; }

    public GenericResult(string message)
    {
        Message = message;
    }

    public GenericResult(string message, object result)
    {
        Message = message;
        Result = result;
    }
}
