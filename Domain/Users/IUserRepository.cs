using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUserRepository
    {
        Task Add(User user, string password);
        Task Update(User user);
        Task Delete(User user);
        Task<User?> FindById(string id);
        Task<User?> FindByEmail(string email);
        Task<bool> CheckPassword(User user, string password);
        Task<List<User>> GetAll();

    }
}
