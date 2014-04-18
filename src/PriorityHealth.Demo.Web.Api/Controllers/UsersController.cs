using PriorityHealth.Core.Domain.Model.Users;
using PriorityHealth.Demo.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PriorityHealth.Demo.Web.Api.Controllers
{
    public class UsersController : ApiController
    {

        protected IUserRepository UsersRepository { get; set; }

        public UsersController(IUserRepository repo)
        {
            UsersRepository = repo;
        }

        public IEnumerable<UserModel> Get()
        {
            var users = UsersRepository.GetAll();
            return users.Select(u => UserModel.FromDomain(u)).ToList();
        }

        public UserModel Get(long id)
        {
            var user = UsersRepository.Get(id);
            return UserModel.FromDomain(user);
        }

        public UserModel Post(CreateUserModel user)
        {
            User entity = AutoMapper.Mapper.Map<User>(user);
            entity.HashPassword();
            UsersRepository.Store(entity);

            return AutoMapper.Mapper.Map<UserModel>(entity);
        }

        public UserModel Put(long id, UserModel user)
        {
            User entity = UsersRepository.Get(id);
            entity = AutoMapper.Mapper.Map(user, entity);
            
            UsersRepository.Store(entity);

            return AutoMapper.Mapper.Map<UserModel>(entity);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            User entity = UsersRepository.Get(id);
            UsersRepository.Delete(entity);
        }
    }
}
