using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.WorkOrders;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class WorkOrderTests
    {

      
        private  string companyName= "Amazons";
        private string designationr ="new work";
       
        private  DateTime beginWork= new DateTime();
        private  DateTime endWork= new DateTime();


        /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */
        [Fact]
        public void WorkOrderConstructor()
        {
            beginWork = DateTime.Now;
            endWork = DateTime.Now;
            
            WorkOrder workOrder = new WorkOrder(companyName,designationr,beginWork,endWork);
            Assert.NotNull(workOrder);
            
            Assert.Equal(workOrder.CompanyName, this.companyName);
            Assert.Equal(workOrder.Designation, this.designationr);
            Assert.Equal(workOrder.BeginWork, this.beginWork);
            Assert.Equal(workOrder.EndWork, this.endWork);
          
        }
       
    }  
    
}