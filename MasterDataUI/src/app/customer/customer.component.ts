
import { FormControl, Validators } from '@angular/forms';

import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { CustomerService } from '../customer.service';
import { ICustomer } from 'src/Model/ICustomer';
import { Observable, Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';




@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  favoriteSearch: string = "Name";
  search: string[] = ['Name', 'Email', 'Country'];

  //SearchRadio: string;
  // seasons: string[] = ['Winter', 'Spring', 'Summer', 'Autumn'];
  searchedUsers: ICustomer[] = [];
  tableColumnHeaders: string[] = ['email', 'name', 'location', 'externalProfileUrl'];
  dataSource = new MatTableDataSource<ICustomer>(this.searchedUsers);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  //message : string = "teste";

  @Output() messageEvent = new EventEmitter<ICustomer>();

  constructor(private userService: CustomerService) {

  }


  ngOnInit(): void {
  }


  getselection(text: string) {

    switch (this.favoriteSearch) {
     /* case "Name": {
        this.getUsersByName(text);
        break;
      }
      case "Email": {
        this.getUsersByEmail(text);
        break;
      }*/
      /*case "Country": {
        this.getUsersByCountry(text);
        break;
      }
      default: {
        this.getUsersByName(text);
        break;
      }*/
    }

  }

/*
  getUsersByName(userName: string) {

    // console.log(userName);
    return this.userService.getUsersByName(userName).subscribe(resultUsers => {
      // console.log(resultUsers);
      this.searchedUsers = resultUsers;
      this.dataSource.data = this.searchedUsers;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      // console.log(this.dataSource.data);
    });
  }
  selectUser(userId: string,company : string) {
    let user : ICustomer = {
                                    id : userId,
                                    company : company
                                  };
    this.messageEvent.emit(user);
   // console.log(userId);
  }
  getUsersByCountry(userCountry: string) {
    return this.userService.getUsersByCountry(userCountry).subscribe(resultUsers => {
      this.searchedUsers = resultUsers;

      this.dataSource.data = this.searchedUsers;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }
*/
 /* getUsersByEmail(userEmail: string) {

    console.log(userEmail);
    return this.userService.getUsersByEmail(userEmail).subscribe(resultUsers => {
      this.searchedUsers = resultUsers;
     // console.log(resultUsers);
      this.dataSource.data = this.searchedUsers;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }*/
 /*changeSort(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }*/

}

