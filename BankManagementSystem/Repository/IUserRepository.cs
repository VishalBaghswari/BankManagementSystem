using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Repository
{
    public interface IUserRepository
    {
        public Task<string> Add(User entity);
        public Task<User> CheckCredentials(string username, string password);

        public Task<User> Get(string id);

        public Task<string> Update(string id,User user);


    }
}
