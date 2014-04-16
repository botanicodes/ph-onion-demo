using PriorityHealth.Core.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository()
            : base("DefaultConnection")
        { }

        public User Get(object id)
        {
            return db.Users.Where(u => u.Id == (int)id).FirstOrDefault<User>();
        }

        public User Load(object id)
        {
            return db.Users.Where(u => u.Id == (int)id).FirstOrDefault<User>();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.AsEnumerable<User>();
        }

        public IEnumerable<User> FindBy(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User FindOneBy(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Query(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Store(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Delete(User entity)
        {
            db.Users.Remove(entity);
            db.SaveChanges();
        }
    }
}
