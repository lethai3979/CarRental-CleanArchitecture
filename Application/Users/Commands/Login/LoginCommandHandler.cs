using Application.Abstraction.Authentication;
using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTProvider _jwtProvider;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IJWTProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(request.Email);
            if (user == null)
            {
                return Result.FailureResult(Error.BadRequest("Wrong email or password"));
            }

            var passwordValid = await _unitOfWork.UserRepository.CheckPassword(user, request.Password);
            if (!passwordValid)
            {
                return Result.FailureResult(Error.BadRequest("Wrong email or password"));
            }

            var token = _jwtProvider.GenerateToken(user);

            return Result<string>.SuccessResult(token);
        }
    }
}
