
using System.Threading.Tasks;
using DDDSample1.Domain.Administrators;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Logins;

using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;


using System.Collections.Generic;
using System.Linq;



using DDDSample1.Infrastructure;



namespace DDDSample1.Infraestructure.Administrators
{
    public class AdministratorRepository : BaseRepository<Administrator, AdministratorId>, IAdministratorRepository
    {
        
    private readonly DbSet<Administrator> _contextJ;

        public AdministratorRepository(DDDSample1DbContext context) : base(context.Administrators)
        {
            _contextJ = context.Administrators;
        }
        public async Task<Administrator> GetByUserAsync(string user)
        {

            var rec = await this._contextJ.SingleOrDefaultAsync(u => u.user.user == user);

            return rec;
        }
       public async Task<Administrator> GetByUserPAssAsync(string user,string pass)
        {

            var rec = await this._contextJ.SingleOrDefaultAsync(u => u.user.user == user && u.password.texto==pass);

            return rec;
        }
 









    }
}