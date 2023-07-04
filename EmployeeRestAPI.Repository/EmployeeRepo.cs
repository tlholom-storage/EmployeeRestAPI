using Dapper;
using EmployeeRestAPI.Interface;
using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DbContext _dbContext;

        public EmployeeRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public async Task DeleteEmployeeById(int id)
        {
            var sproc = "DeleteEmployeeById";
            var param = new { EmployeeCode = id };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }


        public async Task<Employee> GetEmployeeById(int id)
        {
            var sproc = "SelectEmployeeById";
            var param = new { EmployeeCode = id };
            using
            var con = _dbContext.CreateConnection();
            var employee = await con.QueryFirstAsync<Employee>(sproc, param, commandType: System.Data.CommandType.StoredProcedure);

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var sproc = "SelectAllEmployees";
            using
            var con = _dbContext.CreateConnection();
            var employees = await con.QueryAsync<Employee>(sproc, commandType: System.Data.CommandType.StoredProcedure);

            return employees.ToList();
        }

        public async Task InsertEmployee(Employee employee)
        {
            var sproc = "InsertEmployee";
            var param = new { Title = employee.Title, FirstName = employee.FirstName, LastName = employee.LastName, IDNumber = employee.IDNumber, DateOfBirth = employee.DateOfBirth, Gender = employee.Gender,  ContactNumber = employee.ContactNumber, EmailAddress = employee.EmailAddress, DepartmentID = employee.DepartmentID };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var sproc = "UpdateEmployee";
            var param = new { EmployeeCode = employee.EmployeeCode, ContactNumber = employee.ContactNumber, EmailAddress = employee.EmailAddress, DepartmentID = employee.DepartmentID };
            using
            var con = _dbContext.CreateConnection();
            await con.QueryAsync(sproc, param, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
