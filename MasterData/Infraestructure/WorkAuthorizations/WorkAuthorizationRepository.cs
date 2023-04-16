using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.WorkAuthorizations;

namespace DDDSample1.Infraestructure.WorkAuthorizations
{
    public class WorkAuthorizationRepository: BaseRepository<WorkAuthorization, WorkAuthorizationId>, IWorkAuthorizationRepository
    {
        private readonly DbSet<WorkAuthorization> _contextJ;
        
        public WorkAuthorizationRepository(DDDSample1DbContext context):base(context.WorkAuthorizations)
        {
           _contextJ = context.WorkAuthorizations;
        } 

        
        public async Task<List<WorkAuthorization>> GetWorkAuthorizationByCompanyAsync (string Company)
        {

        var rec =await this._contextJ.Where(u=> u.CompanyName.Contains(Company)).ToListAsync();
     
        return rec;
        }

    }
}