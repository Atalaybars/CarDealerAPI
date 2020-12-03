using System;
using AutoMapper;
using CarDealer.DataAccess.DataTransferObjects;
using CarDealer.Entities;

namespace CarDealer.DataAccess.MapperProfiles
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
