using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Shared;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    internal class FindUserByEmailQueryHandler : IQueryHandler<FindUserByEmailQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindUserByEmailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(FindUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(request.Email);
            if (user == null)
            {
                return Result.FailureResult(Error.NotFound("User not found"));
            }
            return Result<User>.SuccessResult(user);
        }
    }
}
