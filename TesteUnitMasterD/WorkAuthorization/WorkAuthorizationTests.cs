using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.WorkAuthorizations;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class WorkAuthorizationTests
    {

        private  string workOrderNumber ="234r-567f-123t";
        private  string companyName= "Amazons";
        private string visualAidNumber ="290f-567a-123t";
       
        public List<ListOfString> employeeNumber = new List<ListOfString>();

        private List<string> employeeNumbe = new List<string>(){"908r-567f-123t"};
   
        private  DateTime beginWork= new DateTime();
        private  DateTime endWork= new DateTime();


        /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */
        [Fact]
        public void WorkAuthorizationConstructor()
        {
                         
            beginWork = DateTime.Now;
            endWork = DateTime.Now;
            
            WorkAuthorization workAuthorization = new WorkAuthorization(workOrderNumber,companyName,visualAidNumber,employeeNumbe,beginWork,endWork);
            Assert.NotNull(workAuthorization);
            Assert.Equal(workAuthorization.WorkOrderNumber, this.workOrderNumber);
            Assert.Equal(workAuthorization.CompanyName, this.companyName);
            Assert.Equal(workAuthorization.VisualAidNumber, this.visualAidNumber);
            Assert.Equal(workAuthorization.BeginWork, this.beginWork);
            Assert.Equal(workAuthorization.EndWork, this.endWork);
        
        }
       
    }  
    
}