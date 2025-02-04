using Application.Abstraction.Commands;
using Application.Companies.Commands.Add;
using Application.UnitOfWork;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.Add
{
    internal sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return Result.FailureResult(Error.InvalidData("Name is required"));
            }
            var company = new Company(new CompanyId(Guid.NewGuid()), request.Name);
            await _unitOfWork.CompanyRepository.Add(company);
            await _unitOfWork.SaveChangesAsync();
            return Result.SuccessResult();
        }
    }
}
