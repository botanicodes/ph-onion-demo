using PriorityHealth.Core.Domain.Model.Users;
using PriorityHealth.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework
{
    public class DemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DemoContext()
            : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DemoContext>(null);
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}