using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BankManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserContext _userContext;
        public UserRepository(UserContext context)
        {
            _userContext = context;
        }
        public async Task<string> Add(User entity)
        {
            await _userContext.Users.AddAsync(entity);
            await _userContext.SaveChangesAsync();
            return ("User Added");
        }

        public async Task<User> CheckCredentials(string username, string password)
        {
            try
            {
                User member = await GetMember(username, password);
                return member;
            }
            catch (Exception)
            {
                return new User();
            }
        }

        public async Task<User> Get(string id)
        {
            return await _userContext.Users.FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<string> Update(string id, User user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
            return ("User Updated");
        }

        private async Task<User> GetMember(string username, string password)
        {
            return await _userContext.Users.FirstAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
