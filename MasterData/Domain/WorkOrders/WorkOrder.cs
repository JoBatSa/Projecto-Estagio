using System;

using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkOrders
{
    public class WorkOrder: Entity<WorkOrderId>, IAggregateRoot
    {
        public string CompanyName { get; private set; }

        public string Designation { get; private set; }

        public DateTime BeginWork {get; private set;}

        public DateTime EndWork {get; private set;}

        public bool Active{ get; private set; }
       
        public WorkOrder()
        {
            this.Active = true;
        }

        public WorkOrder (string companyName, string designation,DateTime beginWork, DateTime endWork)
        {
            this.Id = new WorkOrderId(Guid.NewGuid());
            this.CompanyName = companyName;
            this.Designation = designation;
            this.BeginWork=beginWork;
            this.EndWork=endWork;
           

            this.Active = true;

        }



        public void ChangeEndWorkOrder(DateTime endWork)
            {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the date in an inactive workOrder.");
            this.EndWork =endWork;
            }

        public void MarkAsInative()
             {
                this.Active = false;
             }
    }
}