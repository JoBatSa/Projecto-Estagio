using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkOrders
{
    public interface IWorkOrderRepository: IRepository<WorkOrder, WorkOrderId>
    {
        Task<List<WorkOrder>> GetWorkOrderByCompanyAsync(string company);
    }
}