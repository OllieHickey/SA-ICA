using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Domain.Store
{
    public enum DispatchResult
    {
        None = 0,
        FailedUsageError = 1,
        FailedDispatchError = 2,
        Success = 3
    }
}
