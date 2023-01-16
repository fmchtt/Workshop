using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.Contracts.Results;

public class InvalidDataResult : GenericResult
{
    public InvalidDataResult(string objectName, object invalidObject) : base(objectName, invalidObject)
    {
        Message = $"{objectName} Inválido";
    }
}
