using System;
using AutoMapper;
using CarDealer.DataAccess.DataTransferObjects;
using CarDealer.DTO.DataTransferObjects;
using CarDealer.Entities;

namespace CarDealer.DTO.CarProfiles
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
