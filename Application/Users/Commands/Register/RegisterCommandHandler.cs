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
            using var transaction = await _unitOfWork.BeginTransactionAsync();
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


                var addResult =  await _unitOfWork.UserRepository.Add(user, request.Password);
                if (!addResult.Succeeded)
                {
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", addResult.Errors.Select(e => e.Description))));
                }

                var setRoleResult = await _unitOfWork.UserRepository.SetUserRole(user, Role.Customer);
                if (!setRoleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", setRoleResult.Errors.Select(e => e.Description))));
                }
                await transaction.CommitAsync();
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Result.FailureResult(Error.BadRequest(ex.Message));
            }
        }
    }
}
