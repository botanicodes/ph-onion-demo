using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.Demo.Configuration.Mapping
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<Core.Domain.Model.Users.User, Models.Users.UserModel>()                
                .IgnoreAllNonExisting();

            CreateMap<Models.Users.UserModel, Core.Domain.Model.Users.User>()
                .ForMember(x => x.Id, map => map.Ignore())
                .IgnoreAllNonExisting();

            CreateMap<Models.Users.CreateUserModel, Core.Domain.Model.Users.User>()
                .IgnoreAllNonExisting();
            
            
        }
    }
}
