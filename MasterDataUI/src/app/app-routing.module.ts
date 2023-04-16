import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';

import { NavigationComponent } from './navigation/navigation.component';
import { CustomerComponent } from './customer/customer.component';

import { DeleteReportComponent } from './delete-report/delete-report.component'
import { VisualAidsComponent } from './visual-aids/visual-aids.component';
import { WorkorderComponent } from './workorder/workorder.component';


import { RegisterEmployeesComponent } from './register-employees/register-employees.component';
import { RegisterCustomerComponent } from './register-customer/register-customer.component';
import { CreateWorkorderComponent } from './create-workorder/create-workorder.component';
import { ReportComponent } from './report/report.component';
import { CreateWorkAuthorizationComponent } from './create-work-authorization/create-work-authorization.component';
import { CreateVisualAidComponent } from './create-visual-aid/create-visual-aid.component';

import { MenuZeroComponent } from './menu-zero/menu-zero.component';



import { SearchEmployeeComponent } from './search-employee/search-employee.component';
import { SearchCustomerComponent } from './search-customer/search-customer.component';
import { SearchReportComponent } from './search-report/search-report.component';
import { SearchWorkOrderComponent } from './search-work-order/search-work-order.component';
import { SearchWorkauthorizationComponent } from './search-workauthorization/search-workauthorization.component';
import { SearchVisualAidComponent } from './search-visual-aid/search-visual-aid.component'

import { SearchWorkOrderDialogComponent } from './search-work-order-dialog/search-work-order-dialog.component';
import { SearchEmployeeDialogComponent } from './search-employee-dialog/search-employee-dialog.component';
import { HistoryComponent } from './history/history.component';
import { MenuEditComponent } from './menu-edit/menu-edit.component';


const routes: Routes = [{ path: '', redirectTo: 'login', pathMatch: 'full' },

{ path: '', redirectTo: 'MenuZero', pathMatch: 'full' },


{ path: 'navigation', component:  NavigationComponent},
{ path: 'custumer', component: CustomerComponent },
{ path: 'menuEmployee', component:  EmployeesComponent},



{ path: 'CreateEmployee', component:  RegisterEmployeesComponent},
{ path: 'CreateCustomer', component:  RegisterCustomerComponent},
{ path: 'CreateReport', component:ReportComponent},
{ path: 'CreateWorkOrder', component:CreateWorkorderComponent},
{ path: 'CreateWorkAuth',component:CreateWorkAuthorizationComponent},
{ path: 'CreateVisualAid',component:CreateVisualAidComponent},


{ path: 'DeleteReport', component:DeleteReportComponent},
{ path: 'visualAid', component:VisualAidsComponent},
{ path: 'workorder', component:WorkorderComponent},
{ path: 'menu', component:  MenuComponent},
{ path: 'login', component: LoginComponent },


{ path: 'history', component:  HistoryComponent},


{ path: 'MenuZero', component:  MenuZeroComponent},
{ path: 'MenuEdit', component:  MenuEditComponent},


{ path: 'searchEmployee', component: SearchEmployeeComponent},
{ path: 'searchCustomer', component: SearchCustomerComponent},
{ path: 'searchReport', component: SearchReportComponent },
{ path: 'searchWorkOrder', component:  SearchWorkOrderComponent },
{ path: 'SearchWorkAuth', component: SearchWorkauthorizationComponent},
{ path: 'searchVisualAid', component:  SearchVisualAidComponent },

{ path: 'searchEmployeeDialog', component:  SearchEmployeeDialogComponent},
{ path: 'searchWorkOrderDialog', component:  SearchWorkOrderDialogComponent },


];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
