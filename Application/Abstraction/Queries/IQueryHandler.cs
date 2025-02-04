using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Queries
{
    public interface IQueryHandler<TQuery, TRespone> : IRequestHandler<TQuery, TRespone>
        where TQuery : IQuery<TRespone>
    {
    }
}
