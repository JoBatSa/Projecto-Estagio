using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkOrders
{
    public class WorkOrderService
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkOrderRepository _repo;

        public WorkOrderService(IUnitOfWork unitOfWork, IWorkOrderRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<WorkOrderDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<WorkOrderDto> listDto = list.ConvertAll<WorkOrderDto>(wor => new WorkOrderDto{Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active});

            return listDto;
        }

        public async Task<WorkOrderDto> GetByIdAsync(WorkOrderId id)
        {
            var wor = await this._repo.GetByIdAsync(id);
            
            if(wor == null)
                return null;

            return new WorkOrderDto{Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active};
        }

        public async Task<List<WorkOrderDto>> GetWorkOrderByCompanyAsync(string company)
        {
            var list = await this._repo.GetWorkOrderByCompanyAsync(company);

           
           List<WorkOrderDto> listDto = list.ConvertAll<WorkOrderDto>(wor => new WorkOrderDto{Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active});

            return listDto;
        }


        public async Task<WorkOrderDto> AddAsync(WorkOrderDto dto)
        {
            var wor = new WorkOrder(dto.CompanyName,dto.Designation,dto.BeginWork,dto.EndWork);

            await this._repo.AddAsync(wor);

            await this._unitOfWork.CommitAsync();

            return new WorkOrderDto {Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active};
        }

        public async Task<WorkOrderDto> UpdateAsync(WorkOrderDto dto)
        {
            var wor = await this._repo.GetByIdAsync(new WorkOrderId(dto.Id)); 

            if (wor == null)
                return null;   

           
            wor.ChangeEndWorkOrder(dto.EndWork);
            
            await this._unitOfWork.CommitAsync();

            return new WorkOrderDto {Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active};
        }

        public async Task<WorkOrderDto> InactivateAsync(WorkOrderId id)
        {
            var wor = await this._repo.GetByIdAsync(id); 

            if (wor == null)
                return null;   

            // change all fields
            wor.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new WorkOrderDto {Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active};
        }

         public async Task<WorkOrderDto> DeleteAsync(WorkOrderId id)
        {
            var wor = await this._repo.GetByIdAsync(id); 

            if (wor == null)
                return null;   

            if (wor.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active WorkOrder.");
            
            this._repo.Remove(wor);
            await this._unitOfWork.CommitAsync();

            return new WorkOrderDto {Id = wor.Id.AsGuid(), CompanyName = wor.CompanyName, Designation= wor.Designation, BeginWork= wor.BeginWork, EndWork= wor.EndWork, Active= wor.Active};
        }
    }
}