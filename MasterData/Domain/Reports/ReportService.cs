using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Reports;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.Reports
{
    public class ReportService
    {
        
   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportRepository _repo;

        public ReportService(IUnitOfWork unitOfWork, IReportRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<ReportDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
       //     List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});
            List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber=rep.PartNumber, EmployerName = rep.EmployerName,OkParts=rep.OkParts,NokParts= rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});
            return listDto;
        }

        public List<string> AddListString(List<ListOfString> list)
        {
            List<string> linhasList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(list[i].frase);
            }
            return linhasList;
        }


        public List<int> AddListInt(List<ListofInt> list)
        {
            List<int> linhasList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(list[i].number);
            }
            return linhasList;
        }


        public async Task<ReportDto> GetByIdAsync(ReportId id)
        {
            var rep = await this._repo.GetByIdAsync(id);
            
            if(rep == null)
                return null;

          //  return new ReportDto{Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
       return new ReportDto{Id = rep.Id.AsGuid(),PartNumber= rep.PartNumber, EmployerName = rep.EmployerName,OkParts= rep.OkParts,NokParts= rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
      
        }

        // Pesquisa por nome do funcionario
        public async Task<List<ReportDto>> GetReportByNameAsync(string name)
        {
            var list = await this._repo.GetReportByNameAsync(name);

           

         //   List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});
            List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber= rep.PartNumber, EmployerName = rep.EmployerName,OkParts= rep.OkParts,NokParts= rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});

            return listDto;
        }

        // Pesquisa por nome da empressa
        public async Task<List<ReportDto>> GetReportByCompanyAsync(string company)
        {
            var list = await this._repo.GetReportByCompanyAsync(company);

           

         //   List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});
         List<ReportDto> listDto = list.ConvertAll<ReportDto>(rep => new ReportDto{Id = rep.Id.AsGuid(),PartNumber= rep.PartNumber, EmployerName = rep.EmployerName,OkParts= rep.OkParts,NokParts=rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName});


            return listDto;
        }
/*
        public async Task<ReportDto> AddAsynca(ReportDto dto)
        {
            var rep = new Report(dto.PartNumber,dto.OkParts,dto.NokParts,dto.TimeDate,dto.Observation,dto.WorkOrder,dto.CompanyName,dto.EmployerName);

            await this._repo.AddAsync(rep);

            await this._unitOfWork.CommitAsync();

            return new ReportDto {Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
        }
*/
        public async Task<ReportDto> AddAsync(ReportDto dto)
        {
            var rep = new Report(dto.PartNumber,dto.OkParts,dto.NokParts,dto.TimeDate,dto.Observation,dto.WorkOrder,dto.CompanyName,dto.EmployerName);

            await this._repo.AddAsync(rep);

            await this._unitOfWork.CommitAsync();

            return new ReportDto {Id = rep.Id.AsGuid(),PartNumber= rep.PartNumber, EmployerName = rep.EmployerName,OkParts= rep.OkParts, NokParts=rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
        }

        /*
        public async Task<ReportDto> UpdateAsync(ReportDto dto)
        {
            var Report = await this._repo.GetByIdAsync(new ReportId(dto.Id)); 

            if (Report == null)
                return null;   

            // change all field
            Report.ChangeJobPosition(dto.Job_Position);
            
            await this._unitOfWork.CommitAsync();

            return new ReportDto { Id = Report.Id.AsGuid(), Job_Position = Report.Job_Position.job_Position };
        }
        */
     
        public async Task<ReportDto> DeleteAsync(ReportId id)
        {
            var rep = await this._repo.GetByIdAsync(id); 

            if (rep == null)
                return null;   
            this._repo.Remove(rep);
            await this._unitOfWork.CommitAsync();

          //  return new ReportDto {Id = rep.Id.AsGuid(),PartNumber= AddListString(rep.PartNumber), EmployerName = rep.EmployerName,OkParts= AddListInt(rep.OkParts),NokParts= AddListInt(rep.NokParts),TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
        
         return new ReportDto {Id = rep.Id.AsGuid(),PartNumber= rep.PartNumber, EmployerName = rep.EmployerName,OkParts= rep.OkParts,NokParts= rep.NokParts,TimeDate = rep.TimeDate,Observation= rep.Observation,WorkOrder=rep.WorkOrder, CompanyName=rep.CompanyName};
       
        }




    }
}