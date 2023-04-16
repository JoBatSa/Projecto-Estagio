import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';


import { IEmployee } from 'src/Model/IEmployee'; 


import Swal from 'sweetalert2';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { EmployeesService } from '../employees.service';


@Component({
  selector: 'app-search-employee-dialog',
  templateUrl: './search-employee-dialog.component.html',
  styleUrls: ['./search-employee-dialog.component.css']
})
export class SearchEmployeeDialogComponent implements OnInit {
  favoriteSearch: string = "Name";
  search: string[] = ['All', 'Name'];
 
  searchedEmployee: IEmployee[] = [];
  tableColumnHeaders: string[] = ['id', 'name', 'job_Position','userEmail','userPhoneNumber','active'];
  dataSource = new MatTableDataSource<IEmployee>(this.searchedEmployee);
   @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<IEmployee>();

  resultId?:any;
  resultName?:any;
  resultJob_Position?:any;
  resultUserEmail?:any;
  resultUserPhoneNumber?:any;
  resultPassword?:any;
  resultActive?:any;
  local?:any;



  constructor(private employeeService:EmployeesService) { }

  ngOnInit(): void {
  }



  getselection(text: string) {

    switch (this.favoriteSearch) {
     
      case "All": {
        this.getEmployeeAll();
       
        break;
      }
      case "Name": {
        this.getEmployeeByName(text);
       
        break;
      }
      default: {
        this.getEmployeeAll();
        break;
      }
    }
  }


  getEmployeeByName(name: string) {
    return this.employeeService.getEmployeeByName(name).subscribe(resultEmployees => {
      console.log(resultEmployees);
      this.searchedEmployee = resultEmployees;
      this.dataSource.data = this.searchedEmployee;
      console.log(this.dataSource.data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

 
  getEmployeeAll() {
    return this.employeeService.getEmployeeAll().subscribe(resultEmployees => {
      console.log(resultEmployees);
      this.searchedEmployee = resultEmployees;
      this.dataSource.data = this.searchedEmployee;
     console.log(this.dataSource.data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  selectUser(id: string,name: string, job_Position: number, userEmail:string ,userPhoneNumber:string,  password:string, active:boolean) {
    let user : IEmployee = {
                                    id : id,
                                    name: name,
                                    job_Position: job_Position,
                                    userEmail:userEmail,
                                    userPhoneNumber:userPhoneNumber,
                                    password:password,
                                    active:active,
                                    
  
                                  };
    this.messageEvent.emit(user);
  
  
    this.resultId = id;
    this.resultName = name;
    this.resultJob_Position =job_Position;
    this.resultUserEmail = userEmail;
    this.resultUserPhoneNumber = userPhoneNumber;
    this.resultPassword = password;
    this.resultActive =active;
   }

   changeSort(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}
