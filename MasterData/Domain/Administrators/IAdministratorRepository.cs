
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;


using System.Linq;
using DDDSample1.Infrastructure.Shared;

using DDDSample1.Domain.Employees;


namespace DDDSample1.Domain.Administrators
{
    public interface IAdministratorRepository: IRepository< Administrator,  AdministratorId>
    {

      Task<Administrator> GetByUserAsync(string user);
      Task<Administrator> GetByUserPAssAsync(string user,string pass);

    }
}