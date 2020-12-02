using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarDealer.DataAccess.Abstract;
using CarDealer.Entities;
using Dapper;

namespace CarDealer.DataAccess.Concrete
{
    public class CarRepositoryDapper : ICarRepository
    {
        const string CONNECTIN_STRING = "Server=localhost,1433\\Catalog=CardDB;Database=CarDB;User=sa;Password=reallyStrongPwd#123";

        public async Task<Car> CreateCar(Car car)
        {
            var sql = "CreateCar";

            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return await connection.QueryFirstAsync<Car>

                    (sql, new { Brand = car.Brand, Model = car.Model }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Car> DeleteCar(int id)
        {
            var sql = "DeleteCar";

            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return await connection.QueryFirstAsync<Car>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            var sql = "GetAllCars";

            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return (List<Car>)await connection.QueryAsync<Car>(sql, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Car> GetCarById(int id)
        {
            var sql = "GetById";

            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return await connection.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var sql = "UpdateCar";

            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return await connection.QueryFirstAsync<Car>(sql, new { Model = car.Model, Brand = car.Brand, Id = car.Id }, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
