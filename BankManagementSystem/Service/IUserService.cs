using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Service
{
    public interface IUserService
    {
        public Task<string> AddUser(User entity);
        public Task<User> AuthenticateMember(string username, string password);

        public Task<User> GetUser(string id);
        public Task<string> UpdateUser(string id,User user);
    }
}
