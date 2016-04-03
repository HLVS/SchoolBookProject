using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLib.Core
{
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }
    }
}
