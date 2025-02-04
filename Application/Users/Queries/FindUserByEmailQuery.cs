using Application.Abstraction.Queries;
using Domain.Shared;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public sealed record FindUserByEmailQuery : IQuery<Result>
    {
        public required string Email { get; set; }
    }
}
