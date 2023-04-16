using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DDDSample1.Domain.Employees;
using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;



namespace DDDSample1.Infraestructure.Employees
{
    public class EmployeeRepository: BaseRepository<Employee, EmployeeId>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _contextJ;

        public EmployeeRepository(DDDSample1DbContext context):base(context.Employees)
        {
            _contextJ = context.Employees;
        } 

        public async Task<List<Employee>> GetByNameAsync (string Name)
        {

        var rec =await this._contextJ.Where(u=> u.Name.Contains(Name)).ToListAsync();
     
        return rec;
        }

        public async Task<Employee> GetByEmailPassAsync(string user, string password)
        {

            var rec = await this._contextJ.SingleOrDefaultAsync(u => u.UserEmail.Email == user && u.Password == password);

            return rec;
        }




    }
}