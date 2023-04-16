using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

using DDDSample1.Domain.Customers;

namespace DDDSample1.Domain.Customers
{
    public class CustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _repo;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<CustomerDto> listDto = list.ConvertAll<CustomerDto>(cust => new CustomerDto{Id = cust.Id.AsGuid(), Company = cust.Company, Name = cust.Name, CustomerEmail = cust.CustomerEmail.Email, CustomerPhoneNumber = cust.CustomerPhoneNumber.PhoneNumber, Nif = cust.Nif, Active= cust.Active});

            return listDto;
        }

        public async Task<CustomerDto> GetByIdAsync(CustomerId id)
        {
            var cust = await this._repo.GetByIdAsync(id);
            
            if(cust == null)
                return null;

            return new CustomerDto{Id = cust.Id.AsGuid(), Company = cust.Company, Name = cust.Name, CustomerEmail = cust.CustomerEmail.Email, CustomerPhoneNumber = cust.CustomerPhoneNumber.PhoneNumber, Nif = cust.Nif,Active= cust.Active};
        }

         public async Task<List<CustomerDto>> GetByCompanyAsync(string company)
        {
            var list = await this._repo.GetByCompanyAsync(company);


            List<CustomerDto> listDto = list.ConvertAll<CustomerDto>(cust =>new CustomerDto{Id = cust.Id.AsGuid(), Company = cust.Company, Name = cust.Name, CustomerEmail = cust.CustomerEmail.Email, CustomerPhoneNumber = cust.CustomerPhoneNumber.PhoneNumber, Nif = cust.Nif, Active= cust.Active});

          //  if(cust == null)
             //   return null;

            return listDto;
      
      
      
      
        }





        public async Task<CustomerDto> AddAsync(CustomerDto dto)
        {
            var cust = new Customer(dto.Company,dto.Name,dto.CustomerEmail,dto.CustomerPhoneNumber,dto.Nif,dto.Password);

            await this._repo.AddAsync(cust);

            await this._unitOfWork.CommitAsync();

            return new CustomerDto { Id = cust.Id.AsGuid(), Company = cust.Company , Name= cust.Name , CustomerEmail=cust.CustomerEmail.Email , CustomerPhoneNumber =cust.CustomerPhoneNumber.PhoneNumber , Nif=cust.Nif ,Password =cust.Password,CustPosition= cust.CustPosition.job_Position, Active =cust.Active };
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto dto)
        {
            var cust = await this._repo.GetByIdAsync(new CustomerId(dto.Id)); 

            if (cust == null)
                return null;   

            // change all field
            cust.ChangeDescription(dto.Company);
            
            await this._unitOfWork.CommitAsync();

            return new CustomerDto { Id = cust.Id.AsGuid(), Company = cust.Company , Name= cust.Name , CustomerEmail=cust.CustomerEmail.Email , CustomerPhoneNumber =cust.CustomerPhoneNumber.PhoneNumber , Nif=cust.Nif ,Active =cust.Active };
        }

        public async Task<CustomerDto> InactivateAsync(CustomerId id)
        {
            var cust = await this._repo.GetByIdAsync(id); 

            if (cust == null)
                return null;   

            // change all fields
            cust.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

             return new CustomerDto { Id = cust.Id.AsGuid(), Company = cust.Company , Name= cust.Name , CustomerEmail=cust.CustomerEmail.Email , CustomerPhoneNumber =cust.CustomerPhoneNumber.PhoneNumber , Nif=cust.Nif ,Active =cust.Active };
        }

         public async Task<CustomerDto> DeleteAsync(CustomerId id)
        {
            var cust = await this._repo.GetByIdAsync(id); 

            if (cust == null)
                return null;   

            if (cust.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active customer.");
            
            this._repo.Remove(cust);
            await this._unitOfWork.CommitAsync();

            return new CustomerDto { Id = cust.Id.AsGuid(), Company = cust.Company  };
        }

    }
}