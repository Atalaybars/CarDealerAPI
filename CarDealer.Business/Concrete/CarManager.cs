using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Business.Abstract;
using CarDealer.DataAccess.Abstract;
using CarDealer.Entities;

namespace CarDealer.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarRepository _carRepository;

        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> CreateCar(Car car)
        {
            return await _carRepository.CreateCar(car);
        }

        public async Task<Car> DeleteCar(int id)
        {
            return await _carRepository.DeleteCar(id);
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carRepository.GetCarById(id);
        }

        public async Task<Car> UpdateCar(Car car)
        {
            return await _carRepository.UpdateCar(car);
        }
    }
}
