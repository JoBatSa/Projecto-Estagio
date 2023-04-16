import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IWorkOrder } from 'src/Model/IWorkOrder';
import { WorkOrderDTO } from 'src/app/DTO/WorkOrderDTO'

import { catchError, Observable, of, tap} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class WorkOrderService {

  baseUrl = environment.masterDataApi.ui + '/WorkOrders';  // URL to web api
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };


  addWorkOrder(dto: WorkOrderDTO): Observable<IWorkOrder> {
    return this.http.post<IWorkOrder>(this.baseUrl, dto, this.httpOptions).pipe(
      tap((newLog: IWorkOrder) => this.log(` w/ id=${newLog.id}`)),
        catchError(this.handleError<IWorkOrder>('AddWorkOrder'))
    );
  }


  /*Pesquisa report por company recebe infomaçao de backend*/
  getWorkOrderByCompany(Company: string): Observable<IWorkOrder[]> {
    const url = `${this.baseUrl}/workorder/${Company}`;
    return this.http.get<IWorkOrder[]>(url).pipe(
      catchError(this.handleError<IWorkOrder[]>('get workorders by company'))
    );
  }

  /*Pesquisa report por company recebe infomaçao de backend*/
  getWorkOrderAll(): Observable<IWorkOrder[]> {
    const url = `${this.baseUrl}`;
    return this.http.get<IWorkOrder[]>(url).pipe(
      catchError(this.handleError<IWorkOrder[]>('get WorkOrders by company'))
    );
  }

  /*Pesquisa WorkOrder por id recebe infomaçao de backend*/
  getWorkorderById(Id: string): Observable<IWorkOrder[]> {
    const url = `${this.baseUrl}/${Id}`;
    return this.http.get<IWorkOrder[]>(url).pipe(
      catchError(this.handleError<IWorkOrder[]>('get Workorder by Id'))
    );
  }

  /*Elimina WorkOrder por id envia infomaçao para backend*/
  deleteWorkorderById(Id: string): Observable<IWorkOrder[]> {
    const url = `${this.baseUrl}/hard/${Id}`;
    return this.http.delete<IWorkOrder[]>(url).pipe(
      catchError(this.handleError<IWorkOrder[]>('delete WorkOrder by Id'))
    );
  }

  /*Desactiva workOrder por id envia infomaçao para backend*/
  deactivateCustomerById(id: string): Observable<IWorkOrder> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<IWorkOrder>(url).pipe(
      catchError(this.handleError<IWorkOrder>('deactivate workOrders by Id'))
    );
  }


  private log(message: string) {

    if (message == 'CriarWorkOrder failed: OK') {
      Swal.fire('Erro, nenhuma alteração efectuada');
    }
    else if (message == 'Search WorkOrder failed: OK') {
      Swal.fire('Não existe WorkOrder com este ID');
    } else if (message == 'getAllWorkOrderss,[] failed: OK') {
      Swal.fire('Não existem WorkOrders');
    }
  }
  
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.statusText}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }



}












