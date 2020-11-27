using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Entities;

namespace CarDealer.Business.Abstract
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();

        Task<Car> GetCarById(int id);

        Task<Car> CreateCar(Car car);

        Task<Car> UpdateCar(Car car);

        Task DeleteCar(int id);
    }
}
