using PriorityHealth.Core.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        
    }
}
