using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUserRepository
    {
        Task<IdentityResult> Add(User user, string password);
        Task<IdentityResult> SetUserRole(User user, string role);
        Task<IdentityResult> Update(User user);
        Task<IdentityResult> Delete(User user);
        Task<User?> FindById(string id);
        Task<User?> FindByEmail(string email);
        Task<bool> CheckPassword(User user, string password);
        Task<List<User>> GetAll();
        Task<IList<string>> GetAllUserRoles(User user);

    }
}
