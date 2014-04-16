using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework.Repositories
{
    public class RepositoryBase
    {
        protected DemoContext db = new DemoContext();

        protected string _connectionString;

        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
