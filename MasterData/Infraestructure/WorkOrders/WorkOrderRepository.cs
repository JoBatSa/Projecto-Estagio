using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;

using DDDSample1.Domain.WorkOrders;

namespace DDDSample1.Infraestructure.WorkOrders
{
    public class WorkOrderRepository: BaseRepository<WorkOrder, WorkOrderId>, IWorkOrderRepository
    {
         private readonly DbSet<WorkOrder> _contextJ;
        
        public WorkOrderRepository(DDDSample1DbContext context):base(context.WorkOrders)
        {
            _contextJ = context.WorkOrders;
        } 

        public async Task<List<WorkOrder>> GetWorkOrderByCompanyAsync (string Company)
        {

        var rec =await this._contextJ.Where(u=> u.CompanyName.Contains(Company)).ToListAsync();
     
        return rec;
        }
    }
}