
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeesService } from '../employees.service';

import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import {HostListener} from '@angular/core';
import { CustomerService } from '../customer.service';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-menu-zero',
  templateUrl: './menu-zero.component.html',
  styleUrls: ['./menu-zero.component.css']
})
export class MenuZeroComponent implements OnInit {
  constructor(private router: Router,private employeeService: EmployeesService ,private customerService: CustomerService , private adminService: AdminService,private breakpointObserver1: BreakpointObserver,private breakpointObserver2: BreakpointObserver) {
    this.getScreenHeight();
   }

  local?:any;
  local2?:any;
  addNew?:any;
  search?:any;
  history?:any;

  edit?:any;

  appropriateBottomClass:string = '';
  isHandset$: Observable<boolean> = this.breakpointObserver1
    .observe(Breakpoints.Handset)
    .pipe(map((result) => result.matches),
      shareReplay()
    );

  

  @HostListener('window:resize', ['$event'])
  getScreenHeight() {
    if (window.innerHeight <= 200) {
      this.appropriateBottomClass = 'bottomRelative';
    } else {
      this.appropriateBottomClass = 'bottomStick';
    }
  }

  ngOnInit(): void {
    //this.local = localStorage.getItem('id');
  
    var data = localStorage.getItem('userData')


    var userData = JSON.parse(data!);
    var id = userData.id;
    var tipo = userData.tipo;
    var name = userData.name;
    this.local =id;

    console.log(name);
    console.log(tipo);

if (tipo==0) {
 
  this.menuZero();
  this.local2 = this.getEmployeeId(id);
} else if (tipo<=2 && tipo>=1) {
  this.menuOne();
  this.local2 = this.getEmployeeId(id);
 
} else if (tipo == 3) {
  this.menuThree();
  this.local2 = this.getEmployeeId(id);

} else if (tipo == 4) {
  this.menuFour();
  this.local2 = this.getEmployeeId(id);
 
} else if (tipo == 5) {
  this.menuFive();
  this.local2 = this.getEmployeeId(id);
  console.log('4 e 5');
} else if (tipo == 100) {
  this. menuOneHundred()
  this.local2 = this.getCustomerId(id);
 
} else if (tipo == 1000) {
 // this.local2 = "Administrator";
  this.menuOneThousand()
  this.local2 = "Administrator";
} 



  }

  
  getEmployeeId(id:string) {
      this.employeeService.getEmployeeById(id).subscribe(resultemployee => {
          if(resultemployee==null){
             console.log("teste");
          };
      this.local2 = resultemployee.name;
      console.log(resultemployee.name);
    return resultemployee.name;
      })
  }

  getCustomerId(id:string) {
    this.customerService.getCustumerById(id).subscribe(resultcustomer => {
        if(resultcustomer==null){
           console.log("teste");
        };
    this.local2 = resultcustomer.company;
    console.log(resultcustomer.company);
    return resultcustomer.company;
    })
  }
  
  //---------Intern------------//
  menuZero(){
         
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
         
        ];
      })
    );

  }
  //---------Auditor---------------//
  menuOne(){
    
    this.history = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
         
          { title: 'History', route: '/history' },
          
        ];
      })
    );
   
    this.addNew = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
         
          { title: 'Report', route: '/CreateReport' },
          
        ];
      })
    );
         
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
         
        ];
      })
    );
  }
  //-------Team Leader----------//
  menuThree(){
   
    this.addNew = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employee', route: '/CreateEmployee' },
          { title: 'Customers', route: '/CreateCustomer' },
          { title: 'Report', route: '/CreateReport' },
          { title: 'WorkOrder', route: '/CreateWorkOrder' },
          { title: 'WorkAuthorization', route: '/CreateWorkAuth' },
          { title: 'VisualAid', route: 'CreateVisualAid' },
         
        ];
      })
    );

    this.edit = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
         
          { title: 'Edit', route: '/MenuEdit' },
          
        ];
      })
    );


    
         
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employees', route: '/searchEmployee' },
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
        ];
      })
    );
  }
  ///--------Supervisor---------------///
  menuFour(){
    
    this.addNew = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employee', route: '/CreateEmployee' },
          { title: 'Customers', route: '/CreateCustomer' },
          { title: 'Report', route: '/CreateReport' },
          { title: 'WorkOrder', route: '/CreateWorkOrder' },
          { title: 'WorkAuthorization', route: '/CreateWorkAuth' },
          { title: 'VisualAid', route: 'CreateVisualAid' },
         
        ];
      })
    );
         
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employees', route: '/searchEmployee' },
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
        ];
      })
    );


    this.edit = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
         
          { title: 'Edit', route: '/MenuEdit' },
          
        ];
      })
    );







  }
///---------Manager--------------///
  menuFive(){
   
    this.addNew = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employee', route: '/CreateEmployee' },
          { title: 'Customers', route: '/CreateCustomer' },
          { title: 'Report', route: '/CreateReport' },
          { title: 'WorkOrder', route: '/CreateWorkOrder' },
          { title: 'WorkAuthorization', route: '/CreateWorkAuth' },
          { title: 'VisualAid', route: 'CreateVisualAid' },
         
        ];
      })
    );
         
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employees', route: '/searchEmployee' },
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
        ];
      })
    );
  }
///------- Cliente----------------///
  menuOneHundred(){
             
  this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
        ];
      })
    );
  }
///--------Administrador---------------///
  menuOneThousand(){
    console.log("tese");
    this.addNew = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employee', route: '/CreateEmployee' },
          { title: 'Customers', route: '/CreateCustomer' },
          { title: 'Report', route: '/CreateReport' },
          { title: 'WorkOrder', route: '/CreateWorkOrder' },
          { title: 'WorkAuthorization', route: '/CreateWorkAuth' },
          { title: 'VisualAid', route: 'CreateVisualAid' },
         
        ];
      })
    );
         
   
    this.search = this.breakpointObserver1.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
          { title: 'Employees', route: '/searchEmployee' },
          { title: 'Customers', route: '/searchCustomer' },
          { title: 'Reports', route: '/searchReport' },
          { title: 'WorkOrders', route: '/searchWorkOrder' },
          { title: 'WorkAuthorizations', route: '/SearchWorkAuth' },
          { title: 'VisualAids', route: '/searchVisualAid' },
        ];
      })
    );

    this.edit = this.breakpointObserver2.observe(Breakpoints.Handset).pipe(
      map(() => {
        return [
         
          { title: 'Edit', route: '/MenuEdit' },
          
        ];
      })
    );





  }

  onLogout() {
    
    this.router.navigate(['/login']);
    localStorage.removeItem('userData');
  }


}

