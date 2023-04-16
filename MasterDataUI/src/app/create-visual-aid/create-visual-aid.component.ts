import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { IReport } from 'src/Model/IReport';
import { VisualAidDTO } from '../DTO/VisualAidDTO';
import { VisualAidService } from '../visual-aid.service';
import { EmployeesService } from '../employees.service';

import Swal from 'sweetalert2';


import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatAccordion } from '@angular/material/expansion';
import { IfStmt } from '@angular/compiler';
import { IVisualAid } from 'src/Model/IVisualAid';
import { IWorkOrder } from 'src/Model/IWorkOrder';
import { WorkOrderService } from '../work-order.service';

export interface DialogData {
  Id: string;
  designation: string;
}


@Component({
  selector: 'app-create-visual-aid',
  templateUrl: './create-visual-aid.component.html',
  styleUrls: ['./create-visual-aid.component.css']
})
export class CreateVisualAidComponent implements OnInit {
  searchedWorkOrder!: IWorkOrder ;
  constructor(private visualAidService: VisualAidService,private workOrderService: WorkOrderService,
    private fb: FormBuilder, public dialog: MatDialog,) { }
report: any;
isShown: boolean = false;
registVisualAid!: VisualAidDTO;
local?:any;
nameUser?:any;
idType!:string;
companyType!:any;
designationType?:any;
hide = false;
removable = true;
userType! : string;

pic!:string;
file!: File; // Variable to store file
loading: boolean = false;
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
designation: new FormControl(null, [Validators.pattern('[^\s].*')]),

picture: new FormControl(null, [Validators.pattern('[^\s].*')]),

});

async onSubmit(){
if(this.registerUserFormGroup.valid){
this.registVisualAid = <VisualAidDTO>this.registerUserFormGroup.value;
this.registVisualAid.workOrderNumber=this.idType;
this.registVisualAid.companyName=this.companyType;
this.registVisualAid.designation=this.designationType;




//const formData = new FormData(); 
       
// Store form name as "file" with file data
//formData.append("file", this.file, this.file.name);


//this.registVisualAid.ficheiro = this.file;

//this.registVisualAid.ficheiro = formData;
//this.registVisualAid.picture="";

this.idType= '';
this.companyType='';
this.designationType='';


if(this.registVisualAid.designation==null){
console.log(this.companyType);

Swal.fire({
icon: 'error',
title: 'Empty fields...',
text: 'All fields must be filled!',

})

}else{/*
(await this.visualAidService.addVisualAid(this.registVisualAid)).subscribe((log: IReport) => {
  Swal.fire('Good job!', 'Report successfully created.', 'success' );
this.report = log;
//this. pesqBool() ;
});*/
this.registVisualAid.picture="assets/"+ this.file.name;

 console.log(this.file.name);
  console.log('teste');
 await this.visualAidService.upload(this.file).subscribe((event: any) => {
 
 }); 

 
  this.visualAidService.addVisualAid(this.registVisualAid).subscribe((log: IVisualAid) => {
    Swal.fire('Good job!', 'Visual Aid successfully created.', 'success' );
  this.report = log;
  //this. pesqBool() ;
  });
  //this. pesqBool() ;


}
}
}

/* search by company and returns  id &  company */
userSearchModalDialog(idType : string) {
this.visualAidService.getUpdate().subscribe(response => 
{
this.idType = response.id;
this.companyType = response.companyName;
this.designationType =response.designation;



});
this.dialog.open(VisualAidSearchDialog_VisualAidComponent, {
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

// On file Select
onChange(event: any) {
  this.file = event.target.files[0];
}





}


@Component({
templateUrl: './visualAid-search.html',
styleUrls: ['./create-visual-aid.component.css']
})

export class VisualAidSearchDialog_VisualAidComponent {

@ViewChild(MatAccordion) accordion!: MatAccordion;

constructor(public dialogRef: MatDialogRef<VisualAidSearchDialog_VisualAidComponent>,
@Inject(MAT_DIALOG_DATA) public data: DialogData,
private workOrder : VisualAidService) {}

objectId! : string;    


receiveMessage($event: IWorkOrder){
let object : IWorkOrder = $event;
this.workOrder.sendUpdate(object);
this.dialogRef.close();
// console.log(user.id);
this.objectId= object.id;
this.dialogRef.close();
}


}