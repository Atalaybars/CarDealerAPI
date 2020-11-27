using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.DataAccess.Abstract;
using CarDealer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.Concrete
{
    public class CarRepository : ICarRepository
    {
        public async Task<Car> CreateCar(Car car)
        {
            using (var carDbContext = new CarDbContext())
            {
                carDbContext.Cars.Add(car);
                await carDbContext.SaveChangesAsync();
                return car;
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var carDbContext = new CarDbContext())
            {
                var car = await carDbContext.Cars.FindAsync(id);
                carDbContext.Cars.Remove(car);
                await carDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            using (var carDbContext = new CarDbContext())
            {
                return await carDbContext.Cars.ToListAsync();
            }
        }

        public async Task<Car> GetCarById(int id)
        {
            using (var carDbContext = new CarDbContext())
            {
                return await carDbContext.Cars.FindAsync(id);
            }
        }

        public async Task<Car> UpdateCar(Car car)
        {
            using (var carDbContext = new CarDbContext())
            {
                carDbContext.Cars.Update(car);
                await carDbContext.SaveChangesAsync();
                return car;
            }
        }
    }
}
