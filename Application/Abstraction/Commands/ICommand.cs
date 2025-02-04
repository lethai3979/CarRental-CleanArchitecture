using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TRespone> : IRequest<TRespone>
    {
    }   
}
