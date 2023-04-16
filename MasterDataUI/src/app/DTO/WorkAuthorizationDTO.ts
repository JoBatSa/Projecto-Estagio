export interface WorkAuthorizationDTO {
    workOrderNumber:string;
    companyName:string;
    visualAidNumber:string;
    employeeNumber:string[];
    beginWork:Date;
    endWork:Date;
}