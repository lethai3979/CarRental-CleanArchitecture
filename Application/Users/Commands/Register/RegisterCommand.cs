using Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Register
{
    public sealed record RegisterCommand : ICommand
    {
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public string PhoneNumber { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
    }
}
