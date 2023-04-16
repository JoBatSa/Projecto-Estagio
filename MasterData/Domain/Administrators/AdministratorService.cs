using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Employees;

using static DDDSample1.Domain.Logins.Login;
using System;



namespace DDDSample1.Domain.Administrators
{
    public class AdministratorService
    {
        


 private readonly IUnitOfWork _unitOfWork;
        private readonly IAdministratorRepository _repo;

  

        public AdministratorService(IUnitOfWork unitOfWork, IAdministratorRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;

        }


        public async Task<AdministratorDto> GetByUserPassAsync(CreateAdministratorDto dto)
        {
            const string ADMIN = "Admin_XVI";
            if (ADMIN != dto.user) return null;
            var adm = await this._repo.GetByUserAsync(dto.user);
            if (adm == null)
            {

                var admin_ = await this.AddAsync(dto);
                return admin_;
            }
            var admin = await this._repo.GetByUserPAssAsync(dto.user, dto.password);
            if (admin == null) return null;


            return new AdministratorDto { Id = admin.Id.AsGuid(), user = admin.user.toString(),AdminP=admin.AdminP.job_Position };
        }

        public async Task<AdministratorDto> AddAsync(CreateAdministratorDto dto)
        {
            var admin = new Administrator(dto.user);

            await this._repo.AddAsync(admin);

            await this._unitOfWork.CommitAsync();

            return new AdministratorDto { Id = admin.Id.AsGuid(), user = admin.user.toString() };
        }















    }
}