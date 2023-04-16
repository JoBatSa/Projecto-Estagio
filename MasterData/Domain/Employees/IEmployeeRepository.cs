using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Shared;


namespace DDDSample1.Domain.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeId>
    {
        
        Task<List<Employee>> GetByNameAsync(string name);
   
        /* for login*/
        Task<Employee> GetByEmailPassAsync(string user, string pass);
   
    }
}