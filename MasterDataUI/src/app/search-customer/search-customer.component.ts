import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

import Swal from 'sweetalert2';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { CustomerService } from '../customer.service';
import { ICustomer } from 'src/Model/ICustomer';

@Component({
  selector: 'app-search-customer',
  templateUrl: './search-customer.component.html',
  styleUrls: ['./search-customer.component.css']
})
export class SearchCustomerComponent implements OnInit {

  favoriteSearch: string = "Company";
  search: string[] = ['All', 'Company'];
 
  searchedCustomer: ICustomer[] = [];
  searchedCustomers?: ICustomer ;
  tableColumnHeaders: string[] = ['id', 'company', 'name','customerEmail','customerPhoneNumber','nif','active'];
  dataSource = new MatTableDataSource<ICustomer>(this.searchedCustomer);
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<ICustomer>();

  resultId?:any;
  resultCompany?:any;
  resultName?:any;
  resultCustomerEmail?:any;
  resultCustomerPhoneNumber?:any;
  resultNif?:any;
  resultActive?:any;
  local?:any;



  constructor(private customerService:CustomerService) { }

  ngOnInit(): void {
  }



  getselection(text: string) {

    switch (this.favoriteSearch) {
     
      case "All": {
        this.getCustomerAll();
        break;
      }
      case "Company": {
        this.getCustomerByCompany(text);
       // this.getCustomerCompany(text);
        break;
      }
      default: {
        this.getCustomerAll();
        break;
      }
    }
  }

  
  getCustomerByCompany(company: string) {
    return this.customerService.getCustomerByCompany(company).subscribe(resultCustomer => {
      this.searchedCustomer= resultCustomer;
      this.dataSource.data = this.searchedCustomer;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

 
  getCustomerAll() {
    return this.customerService.getCustumerAll().subscribe(resultCustomer => {
      console.log(resultCustomer);
      this.searchedCustomer = resultCustomer;
      this.dataSource.data = this.searchedCustomer;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  selectUser(id: string,company: string, name: string, customerEmail:string ,customerPhoneNumber:string,  nif:string, active:boolean) {
    let user : ICustomer = {
                                    id : id,
                                    company: company,
                                    name: name,
                                    customerEmail:customerEmail,
                                    customerPhoneNumber:customerPhoneNumber,
                                    nif:nif,
                                    active:active,
                                    
  
                                  };
    this.messageEvent.emit(user);
  
  
    this.resultId = id;
    this.resultCompany = company;
    this.resultName =name;
    this.resultCustomerEmail = customerEmail;
    this.resultCustomerPhoneNumber = customerPhoneNumber;
    this.resultNif = nif;
    this.resultActive =active;
   }

   changeSort(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }


  clean(){
    //this.deleteReport(this.resultId);
   
    this.resultId ="";
    this.resultCompany ="";
    this.resultName  ="";
    this.resultCustomerEmail ="";
    this.resultCustomerPhoneNumber ="";
    this.resultNif ="";
    this.resultActive ="";

  }

}
