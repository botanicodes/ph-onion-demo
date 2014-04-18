using PriorityHealth.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase<TEntity>
    {
        public virtual DemoContext Context { get; protected set; }
        public virtual string ConnectionString { get; protected set; }

        public RepositoryBase() : this("DefaultConnection") { }

        public RepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
            Context = new DemoContext(ConnectionString);
        }

        public virtual TEntity Get(object id)
        {
           return Context.Set<TEntity>().SingleOrDefault(u => u.Id.Equals((long)id));            
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FindOneBy(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Store(TEntity entity)
        {
            if (entity.IsNew())
                Context.Set<TEntity>().Add(entity);
            else
                Context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
