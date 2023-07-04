using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Interface
{
    public interface IEmployeeRepo : IDisposable
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<Employee> GetEmployeeById(int id);

        public Task InsertEmployee(Employee employee);

        public Task UpdateEmployee(Employee employee);

        public Task DeleteEmployeeById(int id);
    }
}
