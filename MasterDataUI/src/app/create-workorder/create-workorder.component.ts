import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { IReport } from 'src/Model/IReport';
import { ReportDTO } from '../DTO/ReportDTO';
import { WorkOrderService } from '../work-order.service';
import { EmployeesService } from '../employees.service';

import Swal from 'sweetalert2';


import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';
import { IfStmt } from '@angular/compiler';
import { WorkOrderDTO } from '../DTO/WorkOrderDTO';
import { IWorkOrder } from 'src/Model/IWorkOrder';

@Component({
  selector: 'app-create-workorder',
  templateUrl: './create-workorder.component.html',
  styleUrls: ['./create-workorder.component.css']
})
export class CreateWorkorderComponent implements OnInit {

  constructor(private workOrderService: WorkOrderService,private employeeService: EmployeesService,
    private fb: FormBuilder, public dialog: MatDialog,) { }
 
    isShown: boolean = false;
    registWorkOrder!: WorkOrderDTO;
    nameUser?:any;
    idType!:string;
    companyType!:any;
    hide = false;
    removable = true;
    userType! : string;
   
    readonly separatorKeysCodes = [ENTER, COMMA] as const;
    
    pesqBool() {
      this.isShown = true;
    }
    pesqBoolFalse(){
      this.isShown = false;
    }
  
    registerUserFormGroup: FormGroup = this.fb.group({
    companyName: new FormControl(null, [Validators.required]),
    designation: new FormControl(null, [Validators.required]),
    beginWork: new FormControl(null, [Validators.pattern('[^\s].*')]),
    endWork: new FormControl(null, [Validators.pattern('[^\s].*')]),
    });
  
  async onSubmit(){
    if(this.registerUserFormGroup.valid){
      this.registWorkOrder = <WorkOrderDTO>this.registerUserFormGroup.value;
  
       var cpn =this.registWorkOrder.companyName;
       var dgt =this.registWorkOrder.designation;
       this.cria();
   }

       
    };

      
cria(){
  (this.workOrderService.addWorkOrder(this.registWorkOrder)).subscribe((log: IWorkOrder) => {
        
    Swal.fire('Good job!', 'WorkOrder created successfuly!', 'success' );
this.registerUserFormGroup.reset;
    });
    
this.clean;
}

clean(){
  //this.deleteReport(this.resultId);
 
  this.registerUserFormGroup.reset;
  
}

  ngOnInit(): void {
    var data = localStorage.getItem('userData')
    var userData = JSON.parse(data!);
    var name = userData.name;
    this.nameUser = name;     
  }
  

}
  
