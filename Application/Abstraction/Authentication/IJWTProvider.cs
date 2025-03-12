using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Authentication
{
    public interface IJWTProvider
    {
        string GenerateToken(User user, IList<string> userRoles);
    }
}
