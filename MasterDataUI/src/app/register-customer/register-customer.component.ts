import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';


import { CustomerService } from '../customer.service';
import { ICustomer } from 'src/Model/ICustomer';
import { CustomerDTO } from '../DTO/CustomerDTO';

import Swal from 'sweetalert2';

import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';




@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.css']
})
export class RegisterCustomerComponent implements OnInit {

  constructor(private customerService: CustomerService,private fb: FormBuilder, public dialog: MatDialog ) { }

  customer: any;
  isShown: boolean = false;

  registeCustomer!:CustomerDTO;




  ngOnInit(): void {
  }
  pesqBool() {
    this.isShown = true;
  }
  pesqBoolFalse(){

    this.isShown = false;

  }

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);


  registerUserFormGroup: FormGroup = this.fb.group({
    company: new FormControl(null, [Validators.required]),
    name: new FormControl(null, [Validators.required]),
    customerEmail: this.emailFormControl,
    customerPhoneNumber: new FormControl(null, [Validators.required]),
    nif: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required]),
  });



  async onSubmit(){
    if(this.registerUserFormGroup.valid){
      this.registeCustomer = <CustomerDTO>this.registerUserFormGroup.value;
    // this.registeCustomer.job_Position=this.jobPositionControl.value;
    //  this.registReport.companyName=this.companyType;
  
      (await this.customerService.addCustomer(this.registeCustomer)).subscribe((log: ICustomer) => {
        if(log!=undefined){
          Swal.fire('Good job!', 'Customer profile successfully created.', 'success' );
          this.customer = log;
          this. pesqBool() ;
        }
      });
      }

   
  }
















}
