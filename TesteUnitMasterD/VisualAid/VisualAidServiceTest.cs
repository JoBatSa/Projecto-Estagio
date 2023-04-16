using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.VisualAids;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;


namespace MasterDataTest
{
    public class VisualAidServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IVisualAidRepository> _introductionRepositoryMock = new Mock<IVisualAidRepository>();

        private List<VisualAid> listVisualAids = new List<VisualAid>();

        private List<string> workOrderNumber = new List<string>(){"234r-567f-123t","987r-567f-123t"};

        private List<string> companyName = new List<string>(){"Amazons","Terrazons"};

        private List<string> designation = new List<string>(){"oil foil","tin foil"};

        private List<string> picture = new List<string>(){"oil foil","tin foil"};

        
        [Fact]
        public async Task TestdAddAsync()
        {
            VisualAid visualAid = new VisualAid(workOrderNumber[0],companyName[0],designation[0],picture[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(visualAid)).ReturnsAsync(visualAid);

            var _introductionService = new VisualAidService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new VisualAidDto{WorkOrderNumber =workOrderNumber[0],CompanyName=companyName[0],Designation = designation[0]});

            Assert.Equal(this.workOrderNumber[0], intro.WorkOrderNumber);
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.designation[0], intro.Designation);
                    
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            listVisualAids.Add(new VisualAid(workOrderNumber[0],companyName[0],designation[0],picture[0]));
            listVisualAids.Add(new VisualAid(workOrderNumber[1],companyName[1],designation[1],picture[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listVisualAids);

            var _introductionService = new VisualAidService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= list.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.workOrderNumber[i], list[i].WorkOrderNumber);
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.designation[i], list[i].Designation);
                i++;
            }
        }


        [Fact]
        public async Task TestGetByIdAsync()
        {
            VisualAid visualAid = new VisualAid(workOrderNumber[0],companyName[0],designation[0],picture[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(visualAid.Id)).ReturnsAsync(visualAid);

            var _introductionService = new VisualAidService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(visualAid.Id);

            Assert.Equal(this.workOrderNumber[0], intro.WorkOrderNumber);
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.designation[0], intro.Designation);
           
        }

        [Fact]
        public async Task TestGetByCompanyAsync()
        {
            
            VisualAid visualAid = new VisualAid(workOrderNumber[0],companyName[0],designation[0],picture[0]);
 
            listVisualAids.Add(visualAid);
           
           
            this._introductionRepositoryMock.Setup(repo => repo.GetVisualAidByCompanyAsync(visualAid.CompanyName)).ReturnsAsync(listVisualAids);

            var _introductionService = new VisualAidService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetVisualAidByCompanyAsync(visualAid.CompanyName);
            
            int i =0;
            int con= list.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.workOrderNumber[i], list[i].WorkOrderNumber);
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.designation[i], list[i].Designation);
                i++;
            }
         }
        

    }
}