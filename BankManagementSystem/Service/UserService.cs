using BankManagementSystem.Models;
using BankManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _Repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserService));
        public UserService(IUserRepository Repository)
        {
            _Repository = Repository;
        }
        public async Task<string> AddUser(User entity)
        {
            _log4net.Info("Calling Add method of repository from service");
            return await _Repository.Add(entity);
        }

        public async Task<User> AuthenticateMember(string username, string password)
        {
            _log4net.Info("Calling CheckCredentials method of repository from service");
            User user= await _Repository.CheckCredentials(username,password);
            return user;
        }

        public async Task<User> GetUser(string id)
        {
            _log4net.Info("Calling Get method of repository from service");
            return await _Repository.Get(id);
        }

        public async Task<string> UpdateUser(string id, User user)
        {
            _log4net.Info("Calling Update method of repository from service");
            return await _Repository.Update(id,user);
        }
    }
}
