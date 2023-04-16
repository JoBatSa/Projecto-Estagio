using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.WorkAuthorizations
{
    public class WorkAuthorizationService
    {
        
     private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkAuthorizationRepository _repo;

        public WorkAuthorizationService(IUnitOfWork unitOfWork, IWorkAuthorizationRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<WorkAuthorizationDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<WorkAuthorizationDto> listDto = list.ConvertAll<WorkAuthorizationDto>(wor => new WorkAuthorizationDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active});

            return listDto;
        }

        public async Task<WorkAuthorizationDto> GetByIdAsync(WorkAuthorizationId id)
        {
            var wor = await this._repo.GetByIdAsync(id);
            
            if(wor == null)
                return null;

            return new WorkAuthorizationDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active};
        }


        public async Task<List<WorkAuthorizationDto>> GetWorkAuthorizationByCompanyAsync(string company)
        {
            var list = await this._repo.GetWorkAuthorizationByCompanyAsync(company);

           
            List<WorkAuthorizationDto> listDto = list.ConvertAll<WorkAuthorizationDto>(wor => new WorkAuthorizationDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active});

            return listDto;
        }





        public async Task<WorkAuthorizationDto> AddAsync(WorkAuthorizationDto dto)
        {
            var wor = new WorkAuthorization(dto.WorkOrderNumber,dto.CompanyName,dto.VisualAidNumber,dto.EmployeeNumber,dto.BeginWork,dto.EndWork);

            await this._repo.AddAsync(wor);

            await this._unitOfWork.CommitAsync();

            return new WorkAuthorizationDto {Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active};
        }

        public async Task<WorkAuthorizationDto> UpdateAsync(WorkAuthorizationDto dto)
        {
            var wor = await this._repo.GetByIdAsync(new WorkAuthorizationId(dto.Id)); 

            if (wor == null)
                return null;   

            // change all field
            wor.AddEmployeeToAuthorization(dto.EmployeeNumber);
            
            await this._unitOfWork.CommitAsync();

            return new WorkAuthorizationDto {Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active };
        }

        public List<string> AddListS(List<ListOfString> list)
        {
            List<string> linhasList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(list[i].frase);
            }
            return linhasList;
        }



        public async Task<WorkAuthorizationDto> InactivateAsync(WorkAuthorizationId id)
        {
            var wor = await this._repo.GetByIdAsync(id); 

            if (wor == null)
                return null;   

            // change all fields
            wor.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new WorkAuthorizationDto {Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active};
        }

         public async Task<WorkAuthorizationDto> DeleteAsync(WorkAuthorizationId id)
        {
            var wor = await this._repo.GetByIdAsync(id); 

            if (wor == null)
                return null;   

            if (wor.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active WorkAuthorization.");
            
            this._repo.Remove(wor);
            await this._unitOfWork.CommitAsync();

            return new WorkAuthorizationDto {Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,VisualAidNumber=wor.VisualAidNumber,EmployeeNumber=AddListS(wor.EmployeeNumber), BeginWork=wor.BeginWork,EndWork=wor.EndWork,Active =wor.Active};
        }
    }
}