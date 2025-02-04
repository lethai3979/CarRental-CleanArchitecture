using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.Update
{
    internal sealed class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Name == null)
                {
                    return Result.FailureResult(Error.InvalidData("Name is required"));
                }
                var company = await _unitOfWork.CompanyRepository.GetById(request.Id);
                if (company == null)
                {
                    return Result.FailureResult(Error.NotFound("Company not found"));
                }
                company.Name = request.Name;
                _unitOfWork.CompanyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.OperationFailed(ex.Message));
            }
        }
    }
}
