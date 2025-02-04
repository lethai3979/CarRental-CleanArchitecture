using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand 
    {
    }

    public interface ICommandHandler<TCommand, TRespone> : IRequestHandler<TCommand, TRespone>
        where TCommand : ICommand<TRespone>
    {
    }
}
