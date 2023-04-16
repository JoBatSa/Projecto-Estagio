using System.Threading.Tasks;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Logins;

using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Logins
{
    public class LoginRepository : BaseRepository<Login, LoginId>, ILoginRepository
    {
        private readonly DbSet<Login> _contextJ;

        public LoginRepository(DDDSample1DbContext context) : base(context.Logins)
        {
            _contextJ = context.Logins;
        }
        public async Task<Login> GetByUserAsync(string user)
        {

            var rec = await this._contextJ.SingleOrDefaultAsync(u => u.User.user == user);

            return rec;
        }
    

 
    }
}