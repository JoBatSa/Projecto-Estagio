using System;
using System.Collections.Generic;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;


namespace DDDSample1.Domain.WorkAuthorizations
{
    public class WorkAuthorization: Entity<WorkAuthorizationId>, IAggregateRoot
    {

        public string WorkOrderNumber { get; private set; }

        public string CompanyName { get; private set; }

        public string VisualAidNumber { get; private set; }

        public List<ListOfString> EmployeeNumber { get;  private set; }

        public List<Employee> EmployeeId{get;private set; }

        public DateTime BeginWork {get; private set;}

        public DateTime EndWork {get; private set;}

        public bool Active{ get; private set; }
       
        private WorkAuthorization()
        {
            this.Active = true;
        }

/*

        public WorkAuthorization (string workOrderNumber,string companyName, string visualAidNumber,List<EmployeeDto> employeeNumber,DateTime beginWork, DateTime endWork)
        {
            this.Id = new WorkAuthorizationId(Guid.NewGuid());
            this.WorkOrderNumber= workOrderNumber;
            this.CompanyName = companyName;
            this.VisualAidNumber = visualAidNumber;
           
            this.BeginWork=beginWork;
            this.EndWork=endWork;
          // this.EmployeeId=AddListSt(employeeNumber);
            this.EmployeeId=  AddListSt(employeeNumber);
           
            this.Active = true;

        }

*/

        public WorkAuthorization (string workOrderNumber,string companyName, string visualAidNumber,List<string> employeeNumber,DateTime beginWork, DateTime endWork)
        {
            this.Id = new WorkAuthorizationId(Guid.NewGuid());
            this.WorkOrderNumber= workOrderNumber;
            this.CompanyName = companyName;
            this.VisualAidNumber = visualAidNumber;
            this.EmployeeNumber= AddListS(employeeNumber);
            this.BeginWork=beginWork;
            this.EndWork=endWork;
          // this.EmployeeId=AddListSt(employeeNumber);
           // this.EmployeeId= new List<Employee>();
            this.Active = true;

        }
        public void AddEmployeeToAuthorization(List<string> employeeNumber)
            {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to add employees in to an inactive Authorization.");
            
             for (int i = 0; i < employeeNumber.Count; i++)
            {
                  this.EmployeeNumber.Add(new ListOfString(employeeNumber[i])); 
            }
         
            
            
            
            
          //  this.EmployeeNumber= AddListS(employeeNumber);
            }


       /* public List<EmployeeDto> AddListSt(List<EmployeeDto> list)
        {
        EmployeeDto dto = new EmployeeDto();

            List<EmployeeDto> linhasList = new List<EmployeeDto>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(new EmployeeDto(list[i]));
            }
            return linhasList;
        }

        */
        public List<ListOfString> AddListS(List<string> list)
        {
            List<ListOfString> linhasList = new List<ListOfString>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(new ListOfString(list[i]));
            }
            return linhasList;
        }


       
        public void MarkAsInative()
             {
                this.Active = false;
             }



    }
}