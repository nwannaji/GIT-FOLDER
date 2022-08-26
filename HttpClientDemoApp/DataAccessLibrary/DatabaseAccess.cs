using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly IConfiguration _config;
        public string connectionStringName { get; set; } = "Default";
        public DatabaseAccess(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
        public async Task UpdateDate<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using(IDbConnection con = new SqlConnection(connectionString))
            {
                await con.ExecuteAsync(sql, parameters);
            }
        }
        public async Task DeleteData<T>(string sql, T Id)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using(IDbConnection con = new SqlConnection(connectionString))
            {
                await con.ExecuteAsync(sql, Id);
            }
        }
    }
}
