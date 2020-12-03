using System;
using AutoMapper;
using CarDealer.DataAccess.MapperConfigs.DataTransferObjects;
using CarDealer.Entities;

namespace CarDealer.DataAccess.MapperConfigs.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Car, ReadDto>();
            CreateMap<CreateDto, Car>();
            CreateMap<UpdateDto, Car>();
        }
    }
}
