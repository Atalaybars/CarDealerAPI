using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarDealer.Entities;
using Dapper;

namespace CarDealer.DataAccess.Concrete.CarRepositoryWithDapper
{
    public class DapperHelperMethods
    {
        const string CONNECTIN_STRING = "Server=localhost,1433\\Catalog=CardDB;Database=CarDB;User=sa;Password=reallyStrongPwd#123";


        public static async Task<Car> QueryFirstAsync(string sql, Dictionary<string, object> dictionary)
        {
            using (var connection = new SqlConnection(CONNECTIN_STRING))
            {
                return await connection.QueryFirstAsync<Car>(sql, new DynamicParameters(dictionary), commandType: CommandType.StoredProcedure);
            }
        }

    }
}
