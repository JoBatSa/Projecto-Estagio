import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';


import { IWorkAuthorization } from 'src/Model/IWorkAuthorization'; 
import { WorkAuthorizationDTO } from '../DTO/WorkAuthorizationDTO'; 
import { WorkAuthorizationService } from '../work-authorization.service';

import Swal from 'sweetalert2';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-search-workauthorization',
  templateUrl: './search-workauthorization.component.html',
  styleUrls: ['./search-workauthorization.component.css']
})
export class SearchWorkauthorizationComponent implements OnInit {

  favoriteSearch: string = "Company";
  search: string[] = ['All', 'Company'];
 
  searchedWorkAuth: IWorkAuthorization[] = [];
  tableColumnHeaders: string[] = ['id', 'workOrderNumber', 'companyName','visualAidNumber','employeeNumber','beginWork','endWork','active'];
  dataSource = new MatTableDataSource<IWorkAuthorization>(this.searchedWorkAuth);
   @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<IWorkAuthorization>();

  resultId?:any;
  resultworkOrderNumber?:any;
  resultCompanyName?:any;
  resultVisualAidNumber?:any;
  resultEmployeeNumber?:any;
  resultBeginWork?:any;
  resultEndWork?:any;
  resultActive?:any;
  local?:any;
    
  constructor(private workAuthService: WorkAuthorizationService,) { }

  ngOnInit(): void {
  
  }

  getselection(text: string) {

    switch (this.favoriteSearch) {
     
      case "All": {
        this.getWorkAuthsAll();
       
        break;
      }
      case "Company": {
        this.getWorkAuthsByCompany(text);
       
        break;
      }
      default: {
        this.getWorkAuthsAll();
        break;
      }
    }
  }


  getWorkAuthsByCompany(company: string) {
    return this.workAuthService.getWorkAuthorizationByCompany(company).subscribe(resultWorkAuths => {
      console.log(resultWorkAuths);
      this. searchedWorkAuth = resultWorkAuths;
      this.dataSource.data = this. searchedWorkAuth;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

 
  getWorkAuthsAll() {
    return this.workAuthService.getWorkAuthorizationAll().subscribe(resultWorkAuths => {
      console.log(resultWorkAuths);
      this.searchedWorkAuth = resultWorkAuths;
      this.dataSource.data = this.searchedWorkAuth;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }


  selectUser(id: string,workOrderNumber: string, companyName: string, visualAidNumber:string ,employeeNumber:string[],  beginWork:Date, endWork:Date, active:boolean) {
    let user : IWorkAuthorization = {
                                    id : id,
                                    workOrderNumber: workOrderNumber,
                                    companyName: companyName,
                                    visualAidNumber:visualAidNumber,
                                    employeeNumber:employeeNumber,
                                    beginWork:beginWork,
                                    endWork:endWork,
                                    active:active,
                                    
  
                                  };
    this.messageEvent.emit(user);
  
  
    this.resultId = id;
    this.resultworkOrderNumber = workOrderNumber;
    this.resultCompanyName =companyName;
    this.resultVisualAidNumber = visualAidNumber;
    this.resultEmployeeNumber = employeeNumber;
    this.resultBeginWork = beginWork;
    this.resultEndWork = endWork;
    this.resultActive =active;
   }

  deleteReport(id:string ) {
    return this.workAuthService.deactivateWorkAuthorizationById(id).subscribe(deleteReports => {
    console.log(deleteReports);

      if(deleteReports!=undefined){
        Swal.fire('Delete success.');
      }
    });
  }



  clean(){
    //this.deleteReport(this.resultId);
   


    this.resultId ="";
    this.resultworkOrderNumber ="";
    this.resultCompanyName ="";
    this.resultVisualAidNumber ="";
    this.resultEmployeeNumber ="";
    this.resultBeginWork ="";
    this.resultEndWork ="";
    this.resultActive ="";

  }

  changeSort(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }






}
