import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { IReport } from 'src/Model/IReport';
import { ReportDTO } from '../DTO/ReportDTO';
import { ReportService } from '../report.service';
import { EmployeesService } from '../employees.service';

import Swal from 'sweetalert2';


import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';
import { IfStmt } from '@angular/compiler';


export interface DialogData {
  Id: string
}

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  constructor(private reportService: ReportService,private employeeService: EmployeesService,
                                            private fb: FormBuilder, public dialog: MatDialog,) { }
  report: any;
  isShown: boolean = false;
  registReport!: ReportDTO;
  local?:any;
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
  partNumber: new FormControl(null, [Validators.required]),
  okParts: new FormControl(null, [Validators.required]),
  nokParts: new FormControl(null, [Validators.required]),
  timeDate: new FormControl(null, [Validators.pattern('[^\s].*')]),
  observation: new FormControl(null, [Validators.pattern('[^\s].*')]),
  workOrder: new FormControl(null, [Validators.pattern('[^\s].*')]),
  companyName: new FormControl(null, [Validators.pattern('[^\s].*')]),
  employerName: new FormControl(null, [Validators.pattern('[^\s].*')]),
 
});

async onSubmit(){
  if(this.registerUserFormGroup.valid){
    this.registReport = <ReportDTO>this.registerUserFormGroup.value;
    this.registReport.workOrder=this.idType;
    this.registReport.companyName=this.companyType;
    this.registReport.employerName=this.nameUser;
if(this.registReport.employerName==null|| this.nameUser==null){
  console.log(this.companyType);

  Swal.fire({
    icon: 'error',
    title: 'Empty fields...',
    text: 'All fields must be filled!',
    
  })

}else{
    (await this.reportService.addReport(this.registReport)).subscribe((log: IReport) => {
      Swal.fire('Good job!', 'Report successfully created.', 'success' );
      this.report = log;
      this. pesqBool() ;
     });}
    }
  }

/* search by company and returns  id &  company */
  userSearchModalDialog(userType : string) {
      this.reportService.getUpdate().subscribe(response => 
      {
          this.idType = response.id;
          this.companyType = response.companyName;
       
      });
    this.dialog.open(ReportSearchDialog_ReportComponent, {
    width: '60%',
    data: {},
      });
}

ngOnInit(): void {
  var data = localStorage.getItem('userData')


  var userData = JSON.parse(data!);
  var id = userData.id;
  var tipo = userData.tipo;
  var name = userData.name;
  this.nameUser = name;


  
}


}


@Component({
  templateUrl: './report-search.html',
  styleUrls: ['./report.component.css']
})

export class ReportSearchDialog_ReportComponent {

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  
  constructor(public dialogRef: MatDialogRef<ReportSearchDialog_ReportComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private report : ReportService) {}

  objectId! : string;    


  receiveMessage($event: IReport){
  let object : IReport = $event;
  this.report.sendUpdate(object);
  this.dialogRef.close();
   // console.log(user.id);
  this.objectId= object.id;
  }
       
  
}