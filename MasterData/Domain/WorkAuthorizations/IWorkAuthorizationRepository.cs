using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkAuthorizations
{
    public interface IWorkAuthorizationRepository: IRepository<WorkAuthorization, WorkAuthorizationId>
    {
      
    
          
        Task<List<WorkAuthorization>> GetWorkAuthorizationByCompanyAsync(string company);
    }
}