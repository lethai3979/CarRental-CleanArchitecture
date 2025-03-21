using Application.Abstraction;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Cars.Commands.Update
{
    public sealed record UpdateCarCommand : ICommand<Result>
    {
        [JsonIgnore]
        public CarId? Id { get; set; }
        public required string Name { get; set; }
        public required int Seats { get; set; }
        public required decimal Price { get; set; }
        public required CarTypeId CarTypeId { get; set; }
        public required CompanyId CompanyId { get; set; }
    }
}
