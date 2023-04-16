using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.WorkAuthorizations;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;


namespace MasterDataTest
{
    public class WorkAuthorizationServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IWorkAuthorizationRepository> _introductionRepositoryMock = new Mock<IWorkAuthorizationRepository>();

        private List<WorkAuthorization> listWorkAuthorizations = new List<WorkAuthorization>();

        private List<string> workOrderNumber = new List<string>(){"234r-567f-123t","764r-567f-876t"};

        private List<string> companyName = new List<string>(){"Amazons","Terrazons"};

        private List<string> visualAidNumber = new List<string>(){"290f-567a-123t","190f-987a-123t"};

        private List<string> employeeNumber = new List<string>(){"908r-567f-123t","678r-432f-123t"};

        private List<DateTime> beginWork = new List<DateTime>(){DateTime.Now,DateTime.Now};

        private List<DateTime> endWork = new List<DateTime>(){DateTime.Now,DateTime.Now};
         
        private List<string> employeeNumberUP = new List<string>(){"908r-567f-123t","678r-432f-123t","908r-567f-123t","678r-432f-123t"};

        [Fact]
        public async Task TestdAddAsync()
        {
            WorkAuthorization workAuthorization = new WorkAuthorization(workOrderNumber[0],companyName[0],visualAidNumber[0],employeeNumber,beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(workAuthorization)).ReturnsAsync(workAuthorization);

            var _introductionService = new WorkAuthorizationService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new WorkAuthorizationDto{WorkOrderNumber =workOrderNumber[0],CompanyName=companyName[0],VisualAidNumber=visualAidNumber[0], EmployeeNumber =employeeNumber,BeginWork = beginWork[0],EndWork=endWork[0]});

            Assert.Equal(this.workOrderNumber[0], intro.WorkOrderNumber);
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.visualAidNumber[0], intro.VisualAidNumber);
            Assert.Equal(this.employeeNumber, intro.EmployeeNumber);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[0], intro.EndWork);
         
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            listWorkAuthorizations.Add(new WorkAuthorization(workOrderNumber[0],companyName[0],visualAidNumber[0],employeeNumber,beginWork[0],endWork[0]));
            listWorkAuthorizations.Add(new WorkAuthorization(workOrderNumber[1],companyName[1],visualAidNumber[1],employeeNumber,beginWork[1],endWork[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listWorkAuthorizations);

            var _introductionService = new WorkAuthorizationService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= list.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.workOrderNumber[i], list[i].WorkOrderNumber);
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.visualAidNumber[i], list[i].VisualAidNumber);
                Assert.Equal(this.employeeNumber, list[i].EmployeeNumber);
                Assert.Equal(this.beginWork[i], list[i].BeginWork);
                Assert.Equal(this.endWork[i], list[i].EndWork);
                i++;
            }
        }


        [Fact]
        public async Task TestGetByIdAsync()
        {
            WorkAuthorization workAuthorization = new WorkAuthorization(workOrderNumber[0],companyName[0],visualAidNumber[0],employeeNumber,beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(workAuthorization.Id)).ReturnsAsync(workAuthorization);

            var _introductionService = new WorkAuthorizationService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(workAuthorization.Id);

            Assert.Equal(this.workOrderNumber[0], intro.WorkOrderNumber);
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.visualAidNumber[0], intro.VisualAidNumber);
            Assert.Equal(this.employeeNumber, intro.EmployeeNumber);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[0], intro.EndWork);
           
        }

        [Fact]
        public async Task TestGetByCompanyAsync()
        {
            WorkAuthorization workAuthorization = new WorkAuthorization(workOrderNumber[0],companyName[0],visualAidNumber[0],employeeNumber,beginWork[0],endWork[0]);
 
            listWorkAuthorizations.Add(workAuthorization);
           
           
            this._introductionRepositoryMock.Setup(repo => repo.GetWorkAuthorizationByCompanyAsync(workAuthorization.CompanyName)).ReturnsAsync(listWorkAuthorizations);

            var _introductionService = new WorkAuthorizationService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetWorkAuthorizationByCompanyAsync(workAuthorization.CompanyName);
            
            int i =0;
            int con= list.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.workOrderNumber[i], list[i].WorkOrderNumber);
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.visualAidNumber[i], list[i].VisualAidNumber);
                Assert.Equal(this.employeeNumber, list[i].EmployeeNumber);
                Assert.Equal(this.beginWork[i], list[i].BeginWork);
                Assert.Equal(this.endWork[i], list[i].EndWork);
                i++;
            }
         }

        [Fact]
        public async Task TestUpdateAsync()
        {
            WorkAuthorization workAuthorization = new WorkAuthorization(workOrderNumber[0],companyName[0],visualAidNumber[0],employeeNumber,beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(workAuthorization.Id)).ReturnsAsync(workAuthorization);

            var _introductionService = new WorkAuthorizationService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.UpdateAsync(new WorkAuthorizationDto{Id = workAuthorization.Id.AsGuid(),WorkOrderNumber =workOrderNumber[0],CompanyName=companyName[0],VisualAidNumber=visualAidNumber[0], EmployeeNumber =employeeNumber,BeginWork = beginWork[0],EndWork=endWork[0]});

            Assert.Equal(this.workOrderNumber[0], intro.WorkOrderNumber);
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.visualAidNumber[0], intro.VisualAidNumber);
            Assert.Equal(this.employeeNumberUP, intro.EmployeeNumber);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[0], intro.EndWork);
           
         }

    }
}