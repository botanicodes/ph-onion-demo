

namespace PriorityHealth.Demo.Application.Attributes
{
    using Core.Application;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class EnvironmentUsageAttribute : Attribute
    {
        public EnvironmentProfile Environment { get; set; }

        public EnvironmentUsageAttribute(EnvironmentProfile environment)
        {
            Environment = environment;
        }

    }
}
