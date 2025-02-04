using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task Add(User user, string password)
        {
           await _userManager.CreateAsync(user, password);
        }

        public async Task Delete(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<User?> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<User?> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            var isCorrect = await _userManager.CheckPasswordAsync(user, password);
            return isCorrect;
        }

        public async Task Update(User user)
        {
            await _userManager.UpdateAsync(user);
        }
    }
}
