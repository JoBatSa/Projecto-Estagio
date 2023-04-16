import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';


import { EmployeesService } from 'src/app/employees.service';
import { IEmployee } from 'src/Model/IEmployee';
import { EmployeeDTO } from '../DTO/EmployeeDTO'; 

import Swal from 'sweetalert2';

import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';


interface JobPosition {
  value: string;
  viewValue: string;
}
interface JobPositionGroup {

  name: string;
  jobPosition: JobPosition[];
}


@Component({
  selector: 'app-register-employees',
  templateUrl: './register-employees.component.html',
  styleUrls: ['./register-employees.component.css']
})
export class RegisterEmployeesComponent  implements OnInit {
  constructor(private employeesService: EmployeesService,private fb: FormBuilder, public dialog: MatDialog ) { }
  employee: any;
  isShown: boolean = false;
  
  registEmployee!: EmployeeDTO;
  
  
  // variaveis job position
  
  jobPositionControl = new FormControl('');
  jobPositionGroups: JobPositionGroup[] = [
    {
      name: 'Job Position',
      jobPosition: [
        {value: '0', viewValue: 'Intern'},
        {value: '1', viewValue: 'Controler'},
        {value: '2', viewValue: 'Auditor'},
        {value: '3', viewValue: 'Team Leader'},
        {value: '4', viewValue: 'Supervisor'},
        {value: '5', viewValue: 'Manager'},
      ],
    }
  ];
  
  
 
   
 /////////////////
  
  
  
  
  ngOnInit(): void {
    var local = localStorage.getItem('id');
  }
  pesqBool() {
    this.isShown = true;
  }
  pesqBoolFalse(){

    this.isShown = false;

  }

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);


  registerUserFormGroup: FormGroup = this.fb.group({
    name: new FormControl(null, [Validators.required]),
    job_Position: this.jobPositionControl.value,
    userEmail: this.emailFormControl,
    userPhoneNumber: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required]),
  });



  async onSubmit(){
    //this.registEmployee.job_Position=this.jobPositionControl.value;
    if(this.registerUserFormGroup.valid){
      this.registEmployee = <EmployeeDTO>this.registerUserFormGroup.value;
      this.registEmployee.job_Position=this.jobPositionControl.value;
      console.log(this.registEmployee.name);
      console.log(this.registEmployee.job_Position);
      console.log(this.registEmployee.userEmail);
      console.log(this.registEmployee.userPhoneNumber);
      console.log(this.registEmployee.password);



      this.employeesService.addEmployee(this.registEmployee).subscribe((log: IEmployee) => {
        if(log!=undefined){
          
          Swal.fire('Good job!', 'Employee profile successfully created.', 'success' );
          this.employee = log;
          this. pesqBool() ;





       }
      });
      }
  }
}


    















