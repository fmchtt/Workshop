using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.Contracts.Results;

public class SuccessResult : GenericResult
{
    public SuccessResult(string message, object result) : base(message, result)
    {
    }

    public SuccessResult(string message) : base(message)
    {
    }
}
