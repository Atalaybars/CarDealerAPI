using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarDealer.DataAccess.Abstract;
using CarDealer.Entities;
using Dapper;

namespace CarDealer.DataAccess.Concrete.CarRepositoryWithDapper
{
    public class CarRepositoryDapper : ICarRepository
    {

        const string CONNECTIN_STRING = "Server=localhost,1433\\Catalog=CardDB;Database=CarDB;User=sa;Password=reallyStrongPwd#123";


        public async Task<Car> CreateCar(Car car)
        {
            var dictionary = new Dictionary<string, object>();

            dictionary.Add("@Brand", car.Brand);
            dictionary.Add("@Model", car.Model);

            return await DapperHelperMethods.QueryFirstAsync("CreateCar", dictionary);
        }

        public async Task<Car> DeleteCar(int id)
        {
            var dictionary = new Dictionary<string, object>();

            dictionary.Add("@Id", id);

            return await DapperHelperMethods.QueryFirstAsync("DeleteCar", dictionary);
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
            var dictionary = new Dictionary<string, object>();

            dictionary.Add("@Id", car.Id);
            dictionary.Add("@Brand", car.Brand);
            dictionary.Add("@Model", car.Model);

            return await DapperHelperMethods.QueryFirstAsync("UpdateCar", dictionary);

        }
    }
}
