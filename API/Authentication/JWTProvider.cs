using Application.Abstraction.Authentication;
using Domain.Users;

namespace API.Authentication
{
    public class JWTProvider : IJWTProvider
    {
        public string GenerateToken(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
