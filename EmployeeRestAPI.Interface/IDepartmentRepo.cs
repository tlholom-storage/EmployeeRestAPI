using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Interface
{
    public interface IDepartmentRepo: IDisposable
    {

        public Task<IEnumerable<Department>> GetDepartments();

        public Task<Department> GetDepartmentById(int id);

        public Task InsertDepartment(Department department);

        public Task UpdateDepartment(Department department);

        public Task DeleteDepartmentById(int id);

    }
}
