using System;
using System.Collections.Generic;

namespace DDDSample1.Domain.Reports
{
    public class ReportDto
    {
        public Guid Id { get; set; }
/*
        public List<string> PartNumber { get; set; }
        
        public List<int> OkParts { get; set; }
        
        public List<int> NokParts { get; set; }
*/
        
        public string PartNumber { get; set; }
        
        public int OkParts { get; set; }
        
        public int NokParts { get; set; }




        public DateTime TimeDate{get; set;}

        public string Observation { get;  set; }

        public string WorkOrder { get; set; }

        public string CompanyName { get; set; }

        public string EmployerName { get; set; }
        
    }
}