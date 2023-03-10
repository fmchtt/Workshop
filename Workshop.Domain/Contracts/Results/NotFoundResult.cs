using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.Contracts.Results;

public class NotFoundResult : GenericResult
{
    public NotFoundResult(string objectName) : base(objectName)
    {
        Message = $"{objectName} não encontrado";
    }
}
