
using System;
using System.Collections.Generic;

namespace DDDSample1.Domain.WorkOrders
{
    public class WorkOrderDto
    {
        public Guid Id { get; set; }

         public string CompanyName { get; set; }

        public string Designation { get; set; }

        public DateTime BeginWork {get;set;}

        public DateTime EndWork {get; set;}

        public bool Active{ get; set; }








    }
}