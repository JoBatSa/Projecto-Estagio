using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Customers;
using static DDDSample1.Domain.Logins.Login;
using System;
using DDDSample1.Domain.Administrators;
using MasterData.Domain.ValueObjects;


namespace DDDSample1.Domain.Logins
{
    public class LoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginRepository _repo;
        private readonly IEmployeeRepository _repoE;
        private readonly IAdministratorRepository _repoA;
        private readonly ICustomerRepository _repoC;
        public LoginService(IUnitOfWork unitOfWork, ILoginRepository repo, IEmployeeRepository _repoE, IAdministratorRepository _repoA,  ICustomerRepository _repoC)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
                this._repoC= _repoC;
            this._repoE = _repoE;
            this._repoA = _repoA;
        }



        public async Task<LoginDto> GetByIdAsync(LoginId id)
        {
            var recH = await this._repo.GetByIdAsync(id);

            if (recH == null)
                return null;

            return new LoginDto { Id = recH.Id.AsGuid(), Name = recH.Name.text, User = recH.User.toString(), Tipo = recH.tipo.job_Position };
        }

        public async Task<LoginDto> AddAsync(CreateLoginDto dto)
        {
            Login recH = null;
            Guid idU;
            if (dto.user == "Admin_XVI")
            {
                AdministratorService adService = new AdministratorService(_unitOfWork, _repoA);
                var adm = await adService.GetByUserPassAsync(new CreateAdministratorDto( dto.password,dto.user));
                if (adm == null)  throw new BusinessRuleValidationException("Pass ou user errados");
               var admimP = new Job_PositionType(1000); 
                recH = new Login(dto.user, dto.password,admimP );
                idU = adm.Id;
            }
            else
            {
               
                    var userA = await this._repoE.GetByEmailPassAsync(dto.user, dto.password);
                    if(userA== null){
                        var userC = await this._repoC.GetByEmailPassAsync(dto.user, dto.password);
                        idU = userC.Id.AsGuid();


                         var custP = new Job_PositionType(100); 
                        recH = new Login(userC.Name, dto.user,custP);

                    }else{
                    recH = new Login(userA.Name, dto.user, userA.Job_Position);
                    idU = userA.Id.AsGuid();}
                
            }

            await this._repo.AddAsync(recH);

            await this._unitOfWork.CommitAsync();

            return new LoginDto { Id = recH.Id.AsGuid(), IdUser =idU,Name = recH.Name.text, User = recH.User.toString(), Tipo = recH.tipo.job_Position};
        }





        public async Task<LoginDto> DeleteAsync(LoginId id)
        {
            var recH = await this._repo.GetByIdAsync(id);

            if (recH == null)
                return null;


            this._repo.Remove(recH);
            await this._unitOfWork.CommitAsync();

             return new LoginDto { Id = recH.Id.AsGuid(), Name = recH.Name.text, User = recH.User.toString(), Tipo = recH.tipo.job_Position };
        }
    }
}