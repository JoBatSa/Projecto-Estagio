import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ReportService } from '../report.service';
import { IReport } from 'src/Model/IReport';
import { ReportDTO } from '../DTO/ReportDTO';

import Swal from 'sweetalert2';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-search-report',
  templateUrl: './search-report.component.html',
  styleUrls: ['./search-report.component.css']
})
export class SearchReportComponent implements OnInit {

  favoriteSearch: string = "Name";
  search: string[] = ['All','Name', 'Company'];
 
  searchedReports: IReport[] = [];
  tableColumnHeaders: string[] = ['id', 'employerName', 'companyName','timeDate','observation'];
  dataSource = new MatTableDataSource<IReport>(this.searchedReports);
 
  resultId?:any;
  resultEmployeeName?:any;
  resultCompanyName?:any;
  resultPartNumber?:any;
  resultOkParts?:any;
  resultNokParts?:any;
  resultTimeDate?:any;
  resultWorkOrder?:any;
  resultObservation?:any;
  local?:any;
    
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<IReport>();

  constructor(private reportService: ReportService) {

  }

  ngOnInit(): void {
    this.local = localStorage.getItem('id');
  }

  getselection(text: string) {

    switch (this.favoriteSearch) {
     
      case "All": {
        this.getReportAll();
        this.clean();
        break;
      }
      case "Name": {
        this.getReportByName(text);
        this.clean();
        break;
      }
      case "Company": {
        this.getReportByCompany(text);
        this.clean();
        break;
      }
      default: {
        this.getReportAll();
        break;
      }
    }
  }

  getReportByName(name: string) {
    return this.reportService.getReportByName(name).subscribe(resultReports => {
      console.log(resultReports);
      this.searchedReports = resultReports;
      this.dataSource.data = this.searchedReports;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  getReportByCompany(company: string) {
    return this.reportService.getReportByCompany(company).subscribe(resultReports => {
      console.log(resultReports);
      this.searchedReports = resultReports;
      this.dataSource.data = this.searchedReports;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

 
  getReportAll() {
    return this.reportService.getReportAll().subscribe(resultReports => {
      console.log(resultReports);
      this.searchedReports = resultReports;
      this.dataSource.data = this.searchedReports;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }


  deleteReport(id:string ) {
    return this.reportService.deleteReportById(id).subscribe(deleteReports => {
    console.log(deleteReports);

      if(deleteReports!=undefined){
        Swal.fire('Delete success.');
      }
    });
  }


selectUser(id: string, employerName:string, companyName:string, partNumber:string, okParts:number, nokParts:number, timeDate:Date , workOrder:string, observation:string) {
  let user : IReport = {
                                  id : id,
                                  companyName: companyName,
                                  employerName: employerName,
                                  partNumber:partNumber,
                                  okParts:okParts,
                                  nokParts:nokParts,
                                  timeDate:timeDate,
                                  workOrder:workOrder,
                                  observation:observation

                                };
  this.messageEvent.emit(user);


  this.resultId = id;
  this.resultEmployeeName =employerName;
  this.resultCompanyName =companyName;
  this.resultPartNumber = partNumber;
  this.resultOkParts =okParts;
  this.resultNokParts = nokParts;
  this.resultTimeDate= timeDate;
  this.resultWorkOrder =workOrder;
  this.resultObservation =observation;

}

clean(){
  //this.deleteReport(this.resultId);
  this.resultId = "";
  this.resultEmployeeName ="";
  this.resultCompanyName ="";
  this.resultPartNumber = "";
  this.resultOkParts ="";
  this.resultNokParts = "";
  this.resultTimeDate = "";
  this.resultWorkOrder = "";
  this.resultObservation = "";
}

  changeSort(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}


