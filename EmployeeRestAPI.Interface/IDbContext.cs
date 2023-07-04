using System.Data;

namespace EmployeeRestAPI.Interface
{
    public interface IDdContext
    {
        public IDbConnection CreateConnection();
    }
}
