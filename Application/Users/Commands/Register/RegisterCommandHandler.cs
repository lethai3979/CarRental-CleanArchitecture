using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Register
{
    internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };
            await _unitOfWork.UserRepository.Add(user, request.Password);
        }
    }
}
