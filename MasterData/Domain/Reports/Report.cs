using System;
using System.Collections.Generic;
using DDDSample1.Domain.Reports;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.Reports
{

    public class Report : Entity<ReportId>, IAggregateRoot
    {/*
        public List<ListOfString> PartNumber { get;  private set; }
        
        public List<ListofInt> OkParts { get;  private set; }
        
        public List<ListofInt> NokParts { get;  private set; }

    */
        public string PartNumber { get;  private set; }
        
        public int OkParts { get;  private set; }
        
        public int NokParts { get;  private set; }


        public DateTime TimeDate{get;private set;}

        public string Observation { get;  private set; }

        public string WorkOrder { get;  private set; }

        public string CompanyName { get;  private set; }

        public string EmployerName { get;  private set; }
/*
        public Report (List<string> partnumber, List<int> okParts, List<int> nokParts, DateTime timeDate, string observation, string workOrder, string companyName, string employerName)
        {
            this.Id = new ReportId(Guid.NewGuid());
            this.PartNumber = AddListS(partnumber);
            this.OkParts = AddList(okParts);
            this.NokParts = AddList(nokParts);
            this.TimeDate = timeDate;
            this.Observation = observation;
            this.WorkOrder = workOrder;
            this.CompanyName = companyName;
            this.EmployerName = employerName;

        }

*/

        public Report (string partnumber, int okParts, int nokParts, DateTime timeDate, string observation, string workOrder, string companyName, string employerName)
        {
            this.Id = new ReportId(Guid.NewGuid());
            this.PartNumber = partnumber;
            this.OkParts = okParts;
            this.NokParts = nokParts;
            this.TimeDate = timeDate;
            this.Observation = observation;
            this.WorkOrder = workOrder;
            this.CompanyName = companyName;
            this.EmployerName = employerName;

        }

         public List<ListofInt> AddList(List<int> list)
        {
            List<ListofInt> linhasList = new List<ListofInt>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(new ListofInt(list[i]));
            }
        return linhasList;
        }


        public List<ListOfString> AddListS(List<string> list)
        {
            List<ListOfString> linhasList = new List<ListOfString>();

            for (int i = 0; i < list.Count; i++)
            {
                linhasList.Add(new ListOfString(list[i]));
            }
        return linhasList;
        }

        private Report()
         {
           
        }
        
    }
}