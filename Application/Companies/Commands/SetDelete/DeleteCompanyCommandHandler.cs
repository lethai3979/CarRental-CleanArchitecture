using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.SetDelete
{
    internal sealed class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var carList = await _unitOfWork.CarRepository.GetAll();
            carList.Where(c => c.CompanyId == request.Id)
                .ToList()
                .ForEach(car =>
                {
                    car.IsDeleted = request.IsDeleted;
                });

            var company = await _unitOfWork.CompanyRepository.GetById(request.Id);
            if (company == null)
            {
                return Result.FailureResult(Error.NotFound("Company not found"));
            }
            company.IsDeleted = request.IsDeleted;
            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.SaveChangesAsync();
            return Result.SuccessResult();
        }
    }
}
