using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.Core.Domain.Model
{
    public interface IEntity<T> : IEntity where T : IEntity<T>
    {

    }

    public interface IEntity
    {
        bool IsNew();
    }
}
