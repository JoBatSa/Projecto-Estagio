using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.VisualAids;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class VisualAidTests
    {

        private  string workOrderNumber ="234r-567f-123t";
        private  string companyName= "Amazons";
        private string designation ="oil foil";

        private string picture ="oil foil";
      

       /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */
        [Fact]
        public void VisualAidConstructor()
        {
                 
            VisualAid visualAid = new VisualAid(workOrderNumber,companyName,designation,picture);
            Assert.NotNull(visualAid);
            Assert.Equal(visualAid.WorkOrderNumber, this.workOrderNumber);
            Assert.Equal(visualAid.CompanyName, this.companyName);
            Assert.Equal(visualAid.Designation, this.designation);
                     
        }
       
    }  
    
}