using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDDSample1.Domain.Reports;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Reports
{
    public interface IReportRepository: IRepository<Report, ReportId>
    {
           Task<List<Report>> GetReportByNameAsync(string name);

           Task<List<Report>> GetReportByCompanyAsync(string company);
    }
}