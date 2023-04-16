using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace DDDSample1.Domain.VisualAids
{
    public class VisualAidService
    {
      private readonly IUnitOfWork _unitOfWork;
        private readonly IVisualAidRepository _repo;

        public VisualAidService(IUnitOfWork unitOfWork, IVisualAidRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<VisualAidDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<VisualAidDto> listDto = list.ConvertAll<VisualAidDto>(wor => new VisualAidDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,Designation=wor.Designation,CreationDate=wor.CreationDate,Picture=wor.Picture   ,Active =wor.Active});

            return listDto;
        }

        public async Task<VisualAidDto> GetByIdAsync(VisualAidId id)
        {
            var wor = await this._repo.GetByIdAsync(id);
            
            if(wor == null)
                return null;

            return new VisualAidDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,Designation=wor.Designation,CreationDate=wor.CreationDate,Picture=wor.Picture   ,Active =wor.Active};
        }

        // Pesquisa por nome da empressa
        public async Task<List<VisualAidDto>> GetVisualAidByCompanyAsync(string company)
        {
            var list = await this._repo.GetVisualAidByCompanyAsync(company);

           

            List<VisualAidDto> listDto = list.ConvertAll<VisualAidDto>(wor => new VisualAidDto{Id = wor.Id.AsGuid(),WorkOrderNumber=wor.WorkOrderNumber, CompanyName = wor.CompanyName,Designation=wor.Designation,CreationDate=wor.CreationDate, Picture=wor.Picture   ,Active =wor.Active});

            return listDto;
        }

        public async Task<VisualAidDto> AddAsync(VisualAidDto dto)
        {

       //    var caminho= this.OnPostUploadAsync(dto.ficheiro);

            var VisualAid = new VisualAid(dto.WorkOrderNumber,dto.CompanyName,dto.Designation,dto.Picture);

            await this._repo.AddAsync(VisualAid);

            await this._unitOfWork.CommitAsync();

            return new VisualAidDto { Id = VisualAid.Id.AsGuid(), CompanyName = VisualAid.CompanyName,WorkOrderNumber=VisualAid.WorkOrderNumber,Designation=VisualAid.Designation,CreationDate=VisualAid.CreationDate,Active =VisualAid.Active,Picture=VisualAid.Picture };
        }
/*
        public async Task<VisualAidDto> UpdateAsync(VisualAidDto dto)
        {
            var VisualAid = await this._repo.GetByIdAsync(new VisualAidId(dto.Id)); 

            if (VisualAid == null)
                return null;   

            // change all field
            VisualAid.AddEmployeeToAuthorization(dto.EmployeeNumber);
            
            await this._unitOfWork.CommitAsync();

            return new VisualAidDto { Id = VisualAid.Id.AsGuid(), EmployeeNumber = AddListS(VisualAid.EmployeeNumber) };
        }
*/

        public async Task<VisualAidDto> InactivateAsync(VisualAidId id)
        {
            var VisualAid = await this._repo.GetByIdAsync(id); 

            if (VisualAid == null)
                return null;   

            // change all fields
            VisualAid.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new VisualAidDto { Id = VisualAid.Id.AsGuid(), CompanyName = VisualAid.CompanyName };
        }

         public async Task<VisualAidDto> DeleteAsync(VisualAidId id)
        {
            var VisualAid = await this._repo.GetByIdAsync(id); 

            if (VisualAid == null)
                return null;   

            if (VisualAid.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active VisualAid.");
            
            this._repo.Remove(VisualAid);
            await this._unitOfWork.CommitAsync();

            return new VisualAidDto { Id = VisualAid.Id.AsGuid(), CompanyName = VisualAid.CompanyName };
        }

         public async Task<string> OnPostUploadAsync(IFormFile file)
        {

            if (file.Length > 0)
            {
                var filePath = "D:/Zecar/Documents/projecto-estagio/MasterDataUI/src/assets/";

                filePath = filePath + file.FileName;
                if (!System.IO.File.Exists(filePath))
                {

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                 return filePath;

                }
                else
                {
                      throw new BusinessRuleValidationException("Não é possivel guardar a imagem");
                }


            }

             throw new BusinessRuleValidationException("Não existe imagem");

           
        }



    }
}