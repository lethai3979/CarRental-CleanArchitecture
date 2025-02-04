using Application.Abstraction;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Login
{
    internal class LoginCommand : ICommand<Result>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
