using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.WorkOrders;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;


namespace MasterDataTest
{
    public class WorkOrderServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IWorkOrderRepository> _introductionRepositoryMock = new Mock<IWorkOrderRepository>();

        private List<WorkOrder> listWorkOrders = new List<WorkOrder>();
                      
        private List<string> companyName = new List<string>(){"Amazons","Terrazons"};

        private List<string> designation = new List<string>(){"new work","old work"};

        private List<DateTime> beginWork = new List<DateTime>(){DateTime.Now,DateTime.Now};

        private List<DateTime> endWork = new List<DateTime>(){DateTime.Now,DateTime.Now};
       
        [Fact]
        public async Task TestdAddAsync()
        {
            WorkOrder workOrder = new WorkOrder(companyName[0],designation[0],beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(workOrder)).ReturnsAsync(workOrder);

            var _introductionService = new WorkOrderService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new WorkOrderDto{CompanyName=companyName[0],Designation=designation[0],BeginWork = beginWork[0],EndWork=endWork[0]});
           
            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.designation[0], intro.Designation);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[0], intro.EndWork);
         
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
           listWorkOrders.Add(new WorkOrder(companyName[0],designation[0],beginWork[0],endWork[0]));
            listWorkOrders.Add(new WorkOrder(companyName[1],designation[1],beginWork[1],endWork[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listWorkOrders);

            var _introductionService = new WorkOrderService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= list.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.designation[i], list[i].Designation);
                Assert.Equal(this.beginWork[i], list[i].BeginWork);
                Assert.Equal(this.endWork[i], list[i].EndWork);
                i++;
            }
        }


        [Fact]
        public async Task TestGetByIdAsync()
        {
            WorkOrder workOrder = new WorkOrder(companyName[0],designation[0],beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(workOrder.Id)).ReturnsAsync(workOrder);

            var _introductionService = new WorkOrderService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(workOrder.Id);

            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.designation[0], intro.Designation);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[0], intro.EndWork);
           
        }

        [Fact]
        public async Task TestGetByCompanyAsync()
        {
            WorkOrder workOrder = new WorkOrder(companyName[0],designation[0],beginWork[0],endWork[0]);
 
            listWorkOrders.Add(workOrder);
                      
            this._introductionRepositoryMock.Setup(repo => repo.GetWorkOrderByCompanyAsync(workOrder.CompanyName)).ReturnsAsync(listWorkOrders);

            var _introductionService = new WorkOrderService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetWorkOrderByCompanyAsync(workOrder.CompanyName);
            
            int i =0;
            int con= list.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.companyName[i], list[i].CompanyName);
                Assert.Equal(this.designation[i], list[i].Designation);
                Assert.Equal(this.beginWork[i], list[i].BeginWork);
                Assert.Equal(this.endWork[i], list[i].EndWork);
                i++;
            }
         }

        [Fact]
        public async Task TestUpdateAsync()
        {
            endWork.Add(DateTime.Now);

            WorkOrder workOrder = new WorkOrder(companyName[0],designation[0],beginWork[0],endWork[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(workOrder.Id)).ReturnsAsync(workOrder);

            var _introductionService = new WorkOrderService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.UpdateAsync(new WorkOrderDto{Id = workOrder.Id.AsGuid(),CompanyName=companyName[0],Designation=designation[0],BeginWork = beginWork[0],EndWork=endWork[1]});


            Assert.Equal(this.companyName[0], intro.CompanyName);
            Assert.Equal(this.designation[0], intro.Designation);
            Assert.Equal(this.beginWork[0], intro.BeginWork);
            Assert.Equal(this.endWork[1], intro.EndWork);
           
         }

    }
}