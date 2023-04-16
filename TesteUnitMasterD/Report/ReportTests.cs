using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Reports;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class ReportTests
    {

        private  string partNumber ="9087654";
     
        private  int okParts =50;
        private  int nokParts =40;
        
        private  DateTime timeDate= new DateTime();
        
        private string observation ="nada a dizer";
        private  string workOrder ="234r-567f-123t";
        private string company ="Amazons";
        private string name ="Jose Santos";


        /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */

        [Fact]
        public void ReportConstructor()
        {
            timeDate = DateTime.Now;
            
            Report report = new Report(partNumber, okParts,nokParts,timeDate,observation,workOrder, company,name);
            Assert.NotNull(report);
            
            Assert.Equal(report.PartNumber, this.partNumber);
            Assert.Equal(report.OkParts, this.okParts);
            Assert.Equal(report.NokParts, this.nokParts);
            Assert.Equal(report.TimeDate, this.timeDate);
            Assert.Equal(report.Observation, this.observation);
            Assert.Equal(report.WorkOrder, this.workOrder);
            Assert.Equal(report.EmployerName, this.name );
            Assert.Equal(report.CompanyName, this.company);            
        }
       
    }  
    
}