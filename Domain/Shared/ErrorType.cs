using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public enum ErrorType
    {
        None = 0,
        NotFound = 1,
        BadRequest = 3,
        OperationFailed = 4,
        Conflict = 5,
    }
}
