using System;
using Microsoft.AspNetCore.Http;
namespace DDDSample1.Domain.VisualAids
{
    public class VisualAidDto
    {
        
        public Guid Id { get; set; }

        public string WorkOrderNumber { get; set; }

        public string CompanyName { get; set; }

        public string Designation { get; set; }
         public string Picture { get; set; }

        public DateTime CreationDate {get; set;}
          public IFormFile ficheiro{get;set;}

        public bool Active{ get; set; }

      
    }
}