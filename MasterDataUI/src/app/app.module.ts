import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmployeesComponent } from './employees/employees.component';
import { RegisterEmployeesComponent } from './register-employees/register-employees.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';

import { MatSortModule } from '@angular/material/sort';

import {A11yModule} from '@angular/cdk/a11y';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {ClipboardModule} from '@angular/cdk/clipboard';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {PortalModule} from '@angular/cdk/portal';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {CdkStepperModule} from '@angular/cdk/stepper';
import {CdkTableModule} from '@angular/cdk/table';
import {CdkTreeModule} from '@angular/cdk/tree';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatBadgeModule} from '@angular/material/badge';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatCardModule} from '@angular/material/card';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatChipsModule} from '@angular/material/chips';
import {MatStepperModule} from '@angular/material/stepper';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDividerModule} from '@angular/material/divider';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';
import {MatNativeDateModule, MatRippleModule} from '@angular/material/core';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatSliderModule} from '@angular/material/slider';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import {MatTableModule} from '@angular/material/table';
import {MatTabsModule} from '@angular/material/tabs';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatTreeModule} from '@angular/material/tree';
import {OverlayModule} from '@angular/cdk/overlay';

import { MatFormFieldModule } from '@angular/material/form-field';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MatFormField } from '@angular/material/form-field';
import { MenuComponent } from './menu/menu.component';
import { NavigationComponent } from './navigation/navigation.component';
import { CustomerComponent } from './customer/customer.component';
import { AdministratorComponent } from './administrator/administrator.component';

import { VisualAidsComponent } from './visual-aids/visual-aids.component';
import { WorkorderComponent } from './workorder/workorder.component';



import { LayoutModule } from '@angular/cdk/layout';

import { RegisterCustomerComponent } from './register-customer/register-customer.component';

import { DeleteCustomerComponent } from './delete-customer/delete-customer.component';
import { DeleteEmployeeComponent } from './delete-employee/delete-employee.component';

import { ReportDeleteDialog_ReportComponent,DeleteReportComponent } from './delete-report/delete-report.component';



import { MenuZeroComponent } from './menu-zero/menu-zero.component';





import { SearchEmployeeComponent } from './search-employee/search-employee.component';
import { SearchCustomerComponent } from './search-customer/search-customer.component';
import { SearchReportComponent } from './search-report/search-report.component';
import { SearchWorkOrderComponent } from './search-work-order/search-work-order.component';
import { SearchWorkauthorizationComponent } from './search-workauthorization/search-workauthorization.component';
import { SearchVisualAidComponent } from './search-visual-aid/search-visual-aid.component';

import { ReportSearchDialog_ReportComponent,ReportComponent } from './report/report.component';
import { SearchWorkOrderDialogComponent } from './search-work-order-dialog/search-work-order-dialog.component';



import { CreateWorkorderComponent } from './create-workorder/create-workorder.component';
import { VisualAidSearchDialog_WorkAuthComponent,EmployeeSearchDialog_WorkAuthComponent, WorkAuthSearchDialog_WorkAuthComponent, CreateWorkAuthorizationComponent } from './create-work-authorization/create-work-authorization.component';
import { SearchEmployeeDialogComponent } from './search-employee-dialog/search-employee-dialog.component';
import { VisualAidSearchDialog_VisualAidComponent,CreateVisualAidComponent } from './create-visual-aid/create-visual-aid.component';
import { HistoryComponent } from './history/history.component';
import { MenuEditComponent } from './menu-edit/menu-edit.component';
import { SearchVisualAidDialogComponent } from './search-visual-aid-dialog/search-visual-aid-dialog.component';



@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    RegisterEmployeesComponent,
    LoginComponent,
    MenuComponent,
    NavigationComponent,
    CustomerComponent,
    AdministratorComponent,
    ReportComponent,
    VisualAidsComponent,
    WorkorderComponent,

    

    
    ReportDeleteDialog_ReportComponent,

    VisualAidSearchDialog_WorkAuthComponent,
    EmployeeSearchDialog_WorkAuthComponent,
    WorkAuthSearchDialog_WorkAuthComponent,
    SearchEmployeeComponent,
    SearchCustomerComponent,
    SearchReportComponent,
    SearchWorkOrderComponent,
    SearchVisualAidComponent,
    
    SearchWorkauthorizationComponent,
    ReportSearchDialog_ReportComponent,
    VisualAidSearchDialog_VisualAidComponent,
   
    SearchWorkOrderDialogComponent,
    SearchEmployeeDialogComponent,


    

    DeleteCustomerComponent,
    DeleteEmployeeComponent,
    DeleteReportComponent,
    MenuZeroComponent,

    
   
    RegisterCustomerComponent,
    CreateWorkorderComponent,
    CreateWorkAuthorizationComponent,
    SearchEmployeeDialogComponent,
    CreateVisualAidComponent,
    HistoryComponent,
    MenuEditComponent,
    SearchVisualAidDialogComponent,
 
   
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatFormFieldModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatFormFieldModule,
    MatSelectModule,

    MatInputModule,
    MatRadioModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatChipsModule,
    MatExpansionModule,
    MatTabsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
