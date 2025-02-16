using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Register
{
    internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    Name = request.Name,
                    UserName = request.Email,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address
                };
                var result =  await _unitOfWork.UserRepository.Add(user, request.Password);
                if (!result.Succeeded)
                {
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", result.Errors.Select(e => e.Description))));
                }
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.BadRequest(ex.Message));
            }
        }
    }
}
