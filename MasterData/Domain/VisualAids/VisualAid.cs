using System;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.VisualAids
{
    public class VisualAid: Entity<VisualAidId>,IAggregateRoot
    {
       

        public string WorkOrderNumber { get; private set; }

        public string CompanyName { get; private set; }

        public string Designation { get; private set; }

        public string Picture { get; private set; }

        public DateTime CreationDate {get; private set;}

        public bool Active{ get; private set; }

        public VisualAid()
        {
            this.Active = true;
        }

        public VisualAid (string workOrderNumber,string companyName,string designation,string picture){

            this.Id= new VisualAidId(Guid.NewGuid());
            this.WorkOrderNumber= workOrderNumber;
            this.CompanyName = companyName;
            this.Designation= designation;
            this.CreationDate = DateTime.Now;
            this.Picture=picture;
            this.Active = true;

        }



        public void MarkAsInative()
             {
                this.Active = false;
             }


    }
}