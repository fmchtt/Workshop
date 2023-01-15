using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.DTO.Results;

public class NotFoundResultDTO : GenericResultDTO
{
    public NotFoundResultDTO(string objectName) : base(objectName)
    {
        Message = $"{objectName} não encontrado";
    }
}
