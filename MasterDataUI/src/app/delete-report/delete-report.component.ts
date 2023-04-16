import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { IReport } from 'src/Model/IReport';
import { ReportDTO } from '../DTO/ReportDTO';
import { ReportService } from '../report.service';

import Swal from 'sweetalert2';


import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';

export interface DialogData {
  Id: string
}

@Component({
  selector: 'app-delete-report',
  templateUrl: './delete-report.component.html',
  styleUrls: ['./delete-report.component.css']
})
export class DeleteReportComponent implements OnInit {
  constructor(private reportService: ReportService,private fb: FormBuilder, public dialog: MatDialog,) { }
  report: any;
  isShown: boolean = false;


  registReport!: ReportDTO;


  idType!:string;
  companyType!:any;
  partNType!:string;
  okType!:string;
  nokType!:string;
  tDateType!:any;
  obserType!:any;
  nameType!:any;

  hide = false;
  removable = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  

  userType! : string;


  pesqBool() {
    this.isShown = true;
  }
  pesqBoolFalse(){

    this.isShown = false;

  }



  addReport(partNumber: string, okParts: string, nOkParts: string, timeDate:any, observation: any, workOrder: any,
    companyName: string, employerName: string) {
     // console.log(partNumber);
   if(partNumber==''||okParts==''||nOkParts==''||timeDate==''||observation==''||workOrder==''||companyName==''||employerName==''
   ){
    Swal.fire('Todos os campos devem ser preenchidos');

   }
   else{
 
  
    this.addReport(partNumber,okParts,nOkParts, timeDate
      ,  observation,  workOrder,  companyName,  employerName)
     
    }

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

    (await this.reportService.addReport(this.registReport)).subscribe((log: IReport) => {
      Swal.fire('Relatorio Eliminado com sucesso.');
      this.report = log;
     this. pesqBool() ;
     
    });
    }
  }


/* pesquisa pela company e retorna o id e a company */
  userSearchModalDialog(userType : string) {
      this.reportService.getUpdate().subscribe(response => 
      {
          this.idType = response.id;
          this.companyType = response.companyName;


         
          this.partNType= response.partNumber;
          this.okType= response.okParts;
          this.nokType= response.nokParts
          this.tDateType= response.timeDate;
          this.obserType= response.observation;
          this.nameType=response.employerName;
        




       
      });
    this.dialog.open(ReportDeleteDialog_ReportComponent, {
    width: '60%',
    data: {},
      });
}


ngOnInit(): void {
}


}


@Component({
  templateUrl: './delete-report-search.html',
  styleUrls: ['./delete-report.component.css']
})

export class ReportDeleteDialog_ReportComponent {

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  
  constructor(public dialogRef: MatDialogRef<ReportDeleteDialog_ReportComponent>,
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