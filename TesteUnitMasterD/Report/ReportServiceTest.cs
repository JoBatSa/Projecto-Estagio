using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Reports;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;


namespace MasterDataTest
{
    public class ReportServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IReportRepository> _introductionRepositoryMock = new Mock<IReportRepository>();

        private List<Report> listReports = new List<Report>();

        private List<string> partNumber = new List<string>(){"9087654","897654"};

        private List<int> okParts = new List<int>(){48,56};

        private List<int> nokParts = new List<int>(){82,21};

        private List<DateTime> timedate = new List<DateTime>(){DateTime.Now, DateTime.Now};

        private List<string> observation = new List<string>(){"nada a dizer"," talvez assim"};

        private List<string> workOrder = new List<string>(){"234r-567f-123t","890r-891f-456t"};

        private List<string> company = new List<string>(){"Amazons","Terrazons"};

        private List<string> name = new List<string>(){"Jose Santos", "Carlos Santos"};


        [Fact]
        public async Task TestdAddAsync()
        {
            Report report = new Report(partNumber[0],okParts[0],nokParts[0],timedate[0],observation[0],workOrder[0],company[0],name[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(report)).ReturnsAsync(report);

            var _introductionService = new ReportService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new ReportDto{PartNumber =partNumber[0],OkParts=okParts[0],NokParts=nokParts[0], TimeDate =timedate[0],Observation = observation[0],WorkOrder=workOrder[0], CompanyName=company[0],EmployerName=name[0]});

            Assert.Equal(this.partNumber[0], intro.PartNumber);
            Assert.Equal(this.okParts[0], intro.OkParts);
            Assert.Equal(this.nokParts[0], intro.NokParts);
            Assert.Equal(this.timedate[0], intro.TimeDate);
            Assert.Equal(this.observation[0], intro.Observation);
            Assert.Equal(this.workOrder[0], intro.WorkOrder);
            Assert.Equal(this.company[0], intro.CompanyName);
            Assert.Equal(this.name[0], intro.EmployerName);


        }

        [Fact]
        public async Task TestGetAllAsync()
        {
           
            listReports.Add(new Report(partNumber[0],okParts[0],nokParts[0],timedate[0],observation[0],workOrder[0],company[0],name[0]));
            listReports.Add(new Report(partNumber[1],okParts[1],nokParts[1],timedate[1],observation[1],workOrder[1],company[1],name[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listReports);

            var _introductionService = new ReportService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= name.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.partNumber[i], list[i].PartNumber);
                Assert.Equal(this.okParts[i], list[i].OkParts);
                Assert.Equal(this.nokParts[i], list[i].NokParts);
                Assert.Equal(this.timedate[i], list[i].TimeDate);
                Assert.Equal(this.observation[i], list[i].Observation);
                Assert.Equal(this.workOrder[i], list[i].WorkOrder);
                Assert.Equal(this.company[i], list[i].CompanyName);
                Assert.Equal(this.name[i], list[i].EmployerName);
                i++;
            }
        }


        [Fact]
        public async Task TestGetByIdAsync()
        {
            
            Report report = new Report(partNumber[0],okParts[0],nokParts[0],timedate[0],observation[0],workOrder[0],company[0],name[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(report.Id)).ReturnsAsync(report);

            var _introductionService = new ReportService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(report.Id);

            Assert.Equal(this.partNumber[0], intro.PartNumber);
            Assert.Equal(this.okParts[0], intro.OkParts);
            Assert.Equal(this.nokParts[0], intro.NokParts);
            Assert.Equal(this.timedate[0], intro.TimeDate);
            Assert.Equal(this.observation[0], intro.Observation);
            Assert.Equal(this.workOrder[0], intro.WorkOrder);
            Assert.Equal(this.company[0], intro.CompanyName);
            Assert.Equal(this.name[0], intro.EmployerName);
           
        }

        [Fact]
        public async Task TestGetByCompanyAsync()
        {
                        
            Report report = new Report(partNumber[0],okParts[0],nokParts[0],timedate[0],observation[0],workOrder[0],company[0],name[0]);
 
            listReports.Add(report);
           
            this._introductionRepositoryMock.Setup(repo => repo.GetReportByCompanyAsync(report.CompanyName)).ReturnsAsync(listReports);

            var _introductionService = new ReportService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetReportByCompanyAsync(report.CompanyName);
            
            int i =0;
            int con= list.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.partNumber[i], list[i].PartNumber);
                Assert.Equal(this.okParts[i], list[i].OkParts);
                Assert.Equal(this.nokParts[i], list[i].NokParts);
                Assert.Equal(this.timedate[i], list[i].TimeDate);
                Assert.Equal(this.observation[i], list[i].Observation);
                Assert.Equal(this.workOrder[i], list[i].WorkOrder);
                Assert.Equal(this.company[i], list[i].CompanyName);
                Assert.Equal(this.name[i], list[i].EmployerName);
                i++;
            }
         }

        [Fact]
        public async Task TestDeletedAsync()
        {
            
            Report report = new Report(partNumber[0],okParts[0],nokParts[0],timedate[0],observation[0],workOrder[0],company[0],name[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(report.Id)).ReturnsAsync(report);

            var _introductionService = new ReportService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.DeleteAsync(report.Id);

            Assert.Equal(this.partNumber[0], intro.PartNumber);
            Assert.Equal(this.okParts[0], intro.OkParts);
            Assert.Equal(this.nokParts[0], intro.NokParts);
            Assert.Equal(this.timedate[0], intro.TimeDate);
            Assert.Equal(this.observation[0], intro.Observation);
            Assert.Equal(this.workOrder[0], intro.WorkOrder);
            Assert.Equal(this.company[0], intro.CompanyName);
            Assert.Equal(this.name[0], intro.EmployerName);
           
        }









    }
}