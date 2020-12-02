using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Entities;

namespace CarDealer.DataAccess.Abstract
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCars();

        Task<Car> GetCarById(int id);

        Task<Car> CreateCar(Car car);

        Task<Car> UpdateCar(Car car);

        // Dapper ile silinenleri çeviriyorum
        Task<Car> DeleteCar(int id);
    }
}
