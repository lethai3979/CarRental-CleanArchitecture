using Application.Cars.Commands.Update;
using AutoMapper;
using Domain.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, UpdateCarCommand>();
        }
    }
}
