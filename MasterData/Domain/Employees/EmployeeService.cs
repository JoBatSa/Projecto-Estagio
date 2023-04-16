using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Domain.Employees
{
    public class EmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<EmployeeDto> listDto = list.ConvertAll<EmployeeDto>(emp => new EmployeeDto{Id = emp.Id.AsGuid(), Name = emp.Name, Job_Position = emp.Job_Position.job_Position, UserEmail = emp.UserEmail.Email, UserPhoneNumber = emp.UserPhoneNumber.PhoneNumber,Active = emp.Active});

            return listDto;
        }

        public async Task<EmployeeDto> GetByIdAsync(EmployeeId id)
        {
            var emp = await this._repo.GetByIdAsync(id);
            
            if(emp == null)
                return null;

            return new EmployeeDto{Id = emp.Id.AsGuid(), Name = emp.Name, Job_Position = emp.Job_Position.job_Position, UserEmail = emp.UserEmail.Email, UserPhoneNumber = emp.UserPhoneNumber.PhoneNumber, Active = emp.Active};
        }

        // Pesquisa por nome do funcionario
        public async Task<List<EmployeeDto>> GetByNameAsync(string name)
        {
            var list = await this._repo.GetByNameAsync(name);

           

             List<EmployeeDto> listDto = list.ConvertAll<EmployeeDto>(emp => new EmployeeDto{Id = emp.Id.AsGuid(), Name = emp.Name, Job_Position = emp.Job_Position.job_Position, UserEmail = emp.UserEmail.Email, UserPhoneNumber = emp.UserPhoneNumber.PhoneNumber,Active = emp.Active});

            return listDto;
        }


        public async Task<EmployeeDto> AddAsync(EmployeeDto dto)
        {
            var employee = new Employee(dto.Name,dto.Job_Position,dto.UserEmail,dto.UserPhoneNumber,dto.Password);
 try
            {
            await this._repo.AddAsync(employee);

            await this._unitOfWork.CommitAsync();

            }
            catch (DbUpdateException e)
            {
                throw new BusinessRuleValidationException(e.GetBaseException().Message);
            }  

            return new EmployeeDto { Id = employee.Id.AsGuid(), Name = employee.Name, Job_Position= employee.Job_Position.job_Position, UserEmail =employee.UserEmail.Email, UserPhoneNumber = employee.UserPhoneNumber.PhoneNumber, Password = employee.Password, Active = employee.Active};
        }
        // Change job position
        public async Task<EmployeeDto> UpdateAsync(EmployeeDto dto)
        {
            var employee = await this._repo.GetByIdAsync(new EmployeeId(dto.Id)); 

            if (employee == null)
                return null;   

           
            employee.ChangeJobPosition(dto.Job_Position);
            
            await this._unitOfWork.CommitAsync();

            return new EmployeeDto { Id = employee.Id.AsGuid(),  Name = employee.Name, Job_Position= employee.Job_Position.job_Position, UserEmail =employee.UserEmail.Email, UserPhoneNumber = employee.UserPhoneNumber.PhoneNumber, Active = employee.Active};
        }
        // Deacivate(soft delete)
        public async Task<EmployeeDto> InactivateAsync(EmployeeId id)
        {
            var employee = await this._repo.GetByIdAsync(id); 

            if (employee == null)
                return null;   

            
            employee.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new EmployeeDto { Id = employee.Id.AsGuid(),  Name = employee.Name, Job_Position= employee.Job_Position.job_Position, UserEmail =employee.UserEmail.Email, UserPhoneNumber = employee.UserPhoneNumber.PhoneNumber, Active = employee.Active};
        }
        // Hard Delete
         public async Task<EmployeeDto> DeleteAsync(EmployeeId id)
        {
            var Employee = await this._repo.GetByIdAsync(id); 

            if (Employee == null)
                return null;   

            if (Employee.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active Employee.");
            
            this._repo.Remove(Employee);
            await this._unitOfWork.CommitAsync();

            return new EmployeeDto { Id = Employee.Id.AsGuid(), Name = Employee.Name };
        }
    }
}