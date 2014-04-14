using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityHealth.Core.Application
{
    [Flags]
    public enum EnvironmentProfile
    {
        Local = 1,
        Development = 2,
        Test = 4,
        Staging = 8,
        Production = 16,
        Any = 32
    }
}
