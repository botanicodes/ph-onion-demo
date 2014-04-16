using PriorityHealth.Core.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.EntityFramework.Mapping
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        internal UserMap()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Id).IsRequired();
            Property(u => u.Email);
            Property(u => u.Name).HasMaxLength(80);
            Property(u => u.Password);
        }
    }
}
