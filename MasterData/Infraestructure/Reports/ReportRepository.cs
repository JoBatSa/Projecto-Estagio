using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DDDSample1.Domain.Reports;
using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;



namespace DDDSample1.Infraestructure.Reports
{
    public class ReportRepository: BaseRepository<Report, ReportId>, IReportRepository
    {
        private readonly DbSet<Report> _contextJ;

         public ReportRepository(DDDSample1DbContext context):base(context.Reports)
        {
            _contextJ = context.Reports;
        } 

        public async Task<List<Report>> GetReportByNameAsync (string Name)
        {

        var rec =await this._contextJ.Where(u=> u.EmployerName.Contains(Name)).ToListAsync();
     
        return rec;
        }

        public async Task<List<Report>> GetReportByCompanyAsync (string Company)
        {

        var rec =await this._contextJ.Where(u=> u.CompanyName.Contains(Company)).ToListAsync();
     
        return rec;
        }

    }
}