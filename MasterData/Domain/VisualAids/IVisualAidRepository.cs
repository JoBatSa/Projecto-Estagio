using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.VisualAids
{
    public interface IVisualAidRepository: IRepository<VisualAid, VisualAidId>
    {
          Task<List<VisualAid>> GetVisualAidByCompanyAsync(string company);
    }
}