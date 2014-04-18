using Newtonsoft.Json;
using PriorityHealth.Core.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHealth.Demo.Models.Users
{
    
    public class UserModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public static UserModel FromDomain(Core.Domain.Model.Users.User user)
        {
            return AutoMapper.Mapper.Map<UserModel>(user);
        }
    }

    public class CreateUserModel : UserModel
    {        
        public string Password { get; set; }
    }
}
