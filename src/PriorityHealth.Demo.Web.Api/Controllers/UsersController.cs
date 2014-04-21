using PriorityHealth.Core.Domain.Model.Users;
using PriorityHealth.Core.Services;
using PriorityHealth.Demo.Models.Users;
using PriorityHealth.Infrastructure.Caching;
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
        protected ICacheProvider Cache { get; set; }
        protected string CacheKey { get; set; }

        public UsersController(IUserRepository repo, ICacheProvider cache)
        {
            UsersRepository = repo;
            Cache = cache;
            CacheKey = Cache.GenerateKey("Users", "All");
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            IEnumerable<User> users = Cache.Get<IEnumerable<User>>(CacheKey);
            
            if(users == null){
                users = UsersRepository.GetAll();
                Cache.Set(CacheKey, users.ToList());
            }                            

            return users.Select(u => UserModel.FromDomain(u)).ToList();
        }


        [HttpGet]
        public UserModel Get(long id)
        {
            var user = UsersRepository.Get(id);
            return UserModel.FromDomain(user);
        }

        [HttpPost]
        public UserModel Post(CreateUserModel user)
        {
            User entity = AutoMapper.Mapper.Map<User>(user);
            entity.HashPassword();
            UsersRepository.Store(entity);
            Cache.Remove(CacheKey);
            return AutoMapper.Mapper.Map<UserModel>(entity);
        }

        [HttpPut]
        public UserModel Put(long id, UserModel user)
        {
            User entity = UsersRepository.Get(id);
            entity = AutoMapper.Mapper.Map(user, entity);
            
            UsersRepository.Store(entity);
            Cache.Remove(CacheKey);
            return AutoMapper.Mapper.Map<UserModel>(entity);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            User entity = UsersRepository.Get(id);
            Cache.Remove(CacheKey);
            UsersRepository.Delete(entity);
        }
    }
}
