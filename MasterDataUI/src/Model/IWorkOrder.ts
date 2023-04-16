export interface IWorkOrder {
    id:string;
    companyName:string;
    designation:string;
    beginWork?:Date;
    endWork?:Date;
    active?:boolean;
}