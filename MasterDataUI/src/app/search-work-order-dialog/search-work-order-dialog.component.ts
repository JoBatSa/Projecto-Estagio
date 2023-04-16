import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { WorkOrderService } from '../work-order.service';


import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { IWorkOrder } from 'src/Model/IWorkOrder';

@Component({
  selector: 'app-search-work-order-dialog',
  templateUrl: './search-work-order-dialog.component.html',
  styleUrls: ['./search-work-order-dialog.component.css']
})
export class SearchWorkOrderDialogComponent implements OnInit {
  favoriteSearch: string = "Company";
  search: string[] = ['All', 'Company'];

  searchedWorkOrders: IWorkOrder[] = [];
  tableColumnHeaders: string[] = ['id',  'companyName','designation','beginWork','endWork','active'];
  dataSource = new MatTableDataSource<IWorkOrder>(this.searchedWorkOrders);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<IWorkOrder>();
 
  constructor(private workOrderService: WorkOrderService) {
  }

  ngOnInit(): void {
  }

  getselection(text: string) {

    switch (this.favoriteSearch) {
      case "All": {
        this.getWorkOrderAll();
        break;
      }
      case "Company": {
        this.getWorkOrderByCompany(text);
        break;
      }
      default: {
        this.getWorkOrderByCompany(text);
        break;
      }
    }
  }

  getWorkOrderAll() {
    // console.log(userName);
    return this.workOrderService.getWorkOrderAll().subscribe(resultWorkOrders => {
      console.log(resultWorkOrders);
      this.searchedWorkOrders = resultWorkOrders;
      this.dataSource.data = this.searchedWorkOrders;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      // console.log(this.dataSource.data);
    });
  }

  getWorkOrderByCompany(company: string) {
    // console.log(userName);
    return this.workOrderService.getWorkOrderByCompany(company).subscribe(resultWorkOrders => {
      console.log(resultWorkOrders);
      this.searchedWorkOrders = resultWorkOrders;
      this.dataSource.data = this.searchedWorkOrders;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      // console.log(this.dataSource.data);
    });
  }

  selectWorkOrder(id: string, companyName:string ,designation:string) {
    let workorder : IWorkOrder = {
                                    id : id,
                                    companyName: companyName,
                                    designation: designation,
                                   
                                  };
    this.messageEvent.emit(workorder);
   console.log(id);
  }

    changeSort(sortState: Sort) {
      if (sortState.direction) {
        this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      } else {
        this._liveAnnouncer.announce('Sorting cleared');
      }
    }
  
  }
  