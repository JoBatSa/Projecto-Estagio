using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.VisualAids;

namespace DDDSample1.Infraestructure.VisualAids
{
    public class VisualAidRepository: BaseRepository<VisualAid, VisualAidId>, IVisualAidRepository
    {
        private readonly DbSet<VisualAid> _contextJ;
        
        public VisualAidRepository(DDDSample1DbContext context):base(context.VisualAids)
        {
           _contextJ = context.VisualAids;
        } 

         public async Task<List<VisualAid>> GetVisualAidByCompanyAsync (string Company)
        {

        var rec =await this._contextJ.Where(u=> u.CompanyName.Contains(Company)).ToListAsync();
     
        return rec;
        }
    }
}