export interface IWorkAuthorization {
    id:string;
    workOrderNumber?:string;
    companyName?:string;
    visualAidNumber?:string;
    employeeNumber?:string[];
    beginWork?:Date;
    endWork?:Date;
    active?:boolean;
}