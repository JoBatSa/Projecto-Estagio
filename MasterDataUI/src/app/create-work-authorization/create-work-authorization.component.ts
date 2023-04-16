import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';


import Swal from 'sweetalert2';


import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';
import { IfStmt } from '@angular/compiler';
import { WorkAuthorizationDTO } from '../DTO/WorkAuthorizationDTO';
import { IWorkAuthorization } from 'src/Model/IWorkAuthorization';
import { WorkAuthorizationService } from '../work-authorization.service';


export interface DialogData {
  Id: string
 
}



@Component({
  selector: 'app-create-work-authorization',
  templateUrl: './create-work-authorization.component.html',
  styleUrls: ['./create-work-authorization.component.css']
})
export class CreateWorkAuthorizationComponent implements OnInit {

  constructor(private workAuthService: WorkAuthorizationService,
    private fb: FormBuilder, public dialog: MatDialog,) { }
 
    isShown: boolean = false;
    registWorkAuth!: WorkAuthorizationDTO;
    nameUser?:any;
    idWOType!:string;
    idEmpType!:string;
    idVAidType!:string;
    companyType!:any;
    hide = false;
    removable = true;
    userType! : string;
    listEmployee: string []=[];
   
    readonly separatorKeysCodes = [ENTER, COMMA] as const;
    
    pesqBool() {
      this.isShown = true;
    }
    pesqBoolFalse(){
      this.isShown = false;
    }
  
    registerUserFormGroup: FormGroup = this.fb.group({
      workOrderNumber: new FormControl(null, [Validators.pattern('[^\s].*')]),
      companyName: new FormControl(null, [Validators.pattern('[^\s].*')]),
      visualAidNumber: new FormControl(null, [Validators.pattern('[^\s].*')]),
      employeeNumber: new FormControl(null, [Validators.minLength(1)]),
      beginWork: new FormControl(null, [Validators.pattern('[^\s].*')]),
      endWork: new FormControl(null, [Validators.pattern('[^\s].*')]),
    });
  
  async onSubmit(){
    if(this.registerUserFormGroup.valid){
      this.registWorkAuth = <WorkAuthorizationDTO>this.registerUserFormGroup.value;
      this.registWorkAuth.workOrderNumber=this.idWOType;
      this.registWorkAuth.companyName=this.companyType;
      this.registWorkAuth.employeeNumber=this.listEmployee;
      this.registWorkAuth.visualAidNumber=this.idVAidType;
      this.cria();
      console.log(this.registWorkAuth);





     this.idWOType='';
      this.companyType='';

     this.idVAidType='';








     }
 };

  //***** teste lista ******/  
 
add(test:string){

this.listEmployee.push(test);

console.log(test);
}






cria(){
  (this.workAuthService.addWorkAuthorization(this.registWorkAuth)).subscribe((log: IWorkAuthorization) => {
        
    Swal.fire('Good job!', 'WorkAuthorization created successfuly!', 'success' );
    this.registerUserFormGroup.reset;
    });
    
this.clean;
}

clean(){
  //this.deleteReport(this.resultId);
 
  this.registerUserFormGroup.reset;
  
}


/* search by company and returns  id &  company */
workOrderSearchModalDialog(userType : string) {
  this.workAuthService.getUpdate().subscribe(response => 
  {
      this.idWOType = response.id;
      this.companyType = response.companyName;
   
  });
this.dialog.open(WorkAuthSearchDialog_WorkAuthComponent, {
width: '60%',
data: {},
  });
}

/* search by employee and returns  id &  company */
employeeSearchModalDialog(userType : string) {
  this.workAuthService.getUpdateE().subscribe(response => 
  {
      this.idEmpType = response.id;
    this.add(response.id);
   
  });
this.dialog.open(EmployeeSearchDialog_WorkAuthComponent, {
width: '60%',
data: {},
  });
}

/* search by visualAid and returns  id &  company */
visualAidSearchModalDialog(userType : string) {
  this.workAuthService.getUpdateV().subscribe(response => 
  {
      this.idVAidType = response.id;
      //this.companyType = response.companyName;
   
  });
this.dialog.open(VisualAidSearchDialog_WorkAuthComponent, {
width: '60%',
data: {},
  });
}

  ngOnInit(): void {
    var data = localStorage.getItem('userData')
    var userData = JSON.parse(data!);
    var name = userData.name;
    this.nameUser = name;     
  }
  

}
  

@Component({
  templateUrl: './workAuth-search.html',
  styleUrls: ['./create-work-authorization.component.css']
})

export class WorkAuthSearchDialog_WorkAuthComponent {

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  
  constructor(public dialogRef: MatDialogRef<WorkAuthSearchDialog_WorkAuthComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private workAuth : WorkAuthorizationService) {}

  objectId! : string;    


  receiveMessage($event: IWorkAuthorization){
  let object : IWorkAuthorization = $event;
  this.workAuth.sendUpdate(object);
  this.dialogRef.close();
   // console.log(user.id);
  this.objectId= object.id;
  }
       
  
}


@Component({
  templateUrl: './employee-search.html',
  styleUrls: ['./create-work-authorization.component.css']
})

export class EmployeeSearchDialog_WorkAuthComponent {

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  
  constructor(public dialogRef: MatDialogRef<EmployeeSearchDialog_WorkAuthComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private workAuth : WorkAuthorizationService) {}

  objectId! : string;    


  receiveMessage($event: IWorkAuthorization){
  let objectE : IWorkAuthorization = $event;
  this.workAuth.sendUpdateE(objectE);
  this.dialogRef.close();
   // console.log(user.id);
  this.objectId= objectE.id;
  }
       
  
}



@Component({
  templateUrl: './visualAid-search.html',
  styleUrls: ['./create-work-authorization.component.css']
})

export class VisualAidSearchDialog_WorkAuthComponent {

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  
  constructor(public dialogRef: MatDialogRef<VisualAidSearchDialog_WorkAuthComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
              private workAuth : WorkAuthorizationService) {}

  objectId! : string;    


  receiveMessage($event: IWorkAuthorization){
  let objectV : IWorkAuthorization = $event;
  this.workAuth.sendUpdateV(objectV);
  this.dialogRef.close();
   // console.log(user.id);
  this.objectId= objectV.id;
  }
       
  
}