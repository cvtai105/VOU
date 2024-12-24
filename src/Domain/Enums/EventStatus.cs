using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EventStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3,
        Cancelled = 4,
        Ended = 5,
    }
}
