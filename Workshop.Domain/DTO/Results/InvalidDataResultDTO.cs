using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.DTO.Results;

public class InvalidDataResultDTO : GenericResultDTO
{
    public InvalidDataResultDTO(string objectName, object invalidObject) : base(objectName, invalidObject)
    {
        Message = $"{objectName} Inválido";
    }
}
