using Dapper;
using EmployeeRestAPI.Interface;
using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DbContext _dbContext;

        public DepartmentRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var sproc = "SelectAllDepartments";
            using
            var con = _dbContext.CreateConnection();
            var departments = await con.QueryAsync<Department>(sproc,commandType: System.Data.CommandType.StoredProcedure);

            return departments.ToList();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var sproc = "SelectDepartmentById";
            var param = new { DepartmentId = id };
            using
            var con = _dbContext.CreateConnection();
            var department = await con.QueryFirstAsync<Department>(sproc, param, commandType: System.Data.CommandType.StoredProcedure);

            return department;
        }

        public async Task InsertDepartment(Department department)
        {
            var sproc = "InsertDepartment";
            var param = new { DepartmentName = department.DepartmentName };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task DeleteDepartmentById(int id)
        {
            var sproc = "DeleteDepartmentById";
            var param = new { DepartmentId = id };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task UpdateDepartment(Department department)
        {
            var sproc = "UpdateDepartment";
            var param = new { DepartmentId = department.DepartmentID, DepartmentName = department.DepartmentName };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
