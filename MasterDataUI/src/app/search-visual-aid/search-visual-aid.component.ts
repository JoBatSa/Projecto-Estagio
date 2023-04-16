import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { VisualAidService } from '../visual-aid.service';


import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { IVisualAid } from 'src/Model/IVisualAid';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-search-visual-aid',
  templateUrl: './search-visual-aid.component.html',
  styleUrls: ['./search-visual-aid.component.css']
})
export class SearchVisualAidComponent implements OnInit {

  favoriteSearch: string = "Company";
  search: string[] = ['All', 'Company'];
  isShown2: boolean = false;
  //SearchRadio: string;
  
  searchedVisualAids: IVisualAid[] = [];
  tableColumnHeaders: string[] = ['id', 'workOrderNumber', 'companyName','designation'];
  dataSource = new MatTableDataSource<IVisualAid>(this.searchedVisualAids);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer!: LiveAnnouncer;

  @Output() messageEvent = new EventEmitter<IVisualAid>();

  resultId?:any;
  resultCompanyName?:any;
  resultDesignation?:any;
  resultWorkOrder?:any;
  resultCreationDate?:any;
  resultCreationURL?:any;
  resultActive?:any;


  constructor(private visualAidService: VisualAidService) {
  }

  ngOnInit(): void {
  }

  getselection(text: string) {

    switch (this.favoriteSearch) {
      case "All": {
        this.getWorkOrderAll();
        this.clean();
        break;
      }
      case "Company": {
        this.getWorkOrderByCompany(text);
        this.clean();
        break;
      }
      default: {
        this.getWorkOrderByCompany(text);
        break;
      }
    }
  }


  getWorkOrderAll() {
    return this.visualAidService.getVisualAidAll().subscribe(resultVisuaAids => {
      console.log(resultVisuaAids);
      this.searchedVisualAids = resultVisuaAids;
      this.dataSource.data = this.searchedVisualAids;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      // console.log(this.dataSource.data);
    });
  }

  getWorkOrderByCompany(company: string) {
    // console.log(userName);
    return this.visualAidService.getVisualAidByCompany(company).subscribe(resultVisuaAids => {
      console.log(resultVisuaAids);
      this.searchedVisualAids = resultVisuaAids;
      this.dataSource.data = this.searchedVisualAids;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      // console.log(this.dataSource.data);
    });
  }

  selectVisualAid(id: string, companyName:string ,designation:string, workOrder:string, creationDate:Date,picture:string, active:boolean) {
    let visualAid : IVisualAid = {
                                    id : id,
                                    companyName: companyName,
                                   
                                  };
    this.messageEvent.emit(visualAid);
   console.log(id);


   this.resultId = id;
   this.resultCompanyName = companyName;
   this.resultDesignation = designation;
   this.resultWorkOrder = workOrder;
   this.resultCreationDate  = creationDate;
   this.resultCreationURL = picture;
   this.resultActive  = active;
   console.log( this.resultCreationURL);
   console.log( this.resultCreationURL);
 

  }

mostra(){

  this.isShown2 = true;
  console.log( this.resultCreationURL);
}


   
  clean(){
  
    this.isShown2 = false;

    this.resultId = "";
    this.resultCompanyName ="";
    this.resultDesignation = "";
    this.resultWorkOrder = "";
    this.resultCreationDate  = "";
    this.resultActive  = "";
  }

    changeSort(sortState: Sort) {
      if (sortState.direction) {
        this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      } else {
        this._liveAnnouncer.announce('Sorting cleared');
      }
    }




}
