using EmployeeRestAPI.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeRestAPI.Repository
{
    public class DbContext : IDdContext
    {

        private readonly string sqlConnectionString;
        public DbContext(IConfiguration config)
        {
            sqlConnectionString = config.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(sqlConnectionString);
    }
}
