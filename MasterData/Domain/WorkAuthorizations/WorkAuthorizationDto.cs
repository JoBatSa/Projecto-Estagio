using System;
using System.Collections.Generic;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.WorkAuthorizations
{
    public class WorkAuthorizationDto
    {
        
        public Guid Id { get; set; }
        
        public string WorkOrderNumber { get; set; }

        public string CompanyName { get; set; }

        public string VisualAidNumber { get; set; }

        public List<string> EmployeeNumber { get; set; }

         // public List<Guid> EmployeeId { get; set; }

        public DateTime BeginWork {get; set;}

        public DateTime EndWork {get; set;}

        public bool Active{ get; set; }
       
    }
}