import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CustomerDTO } from './DTO/CustomerDTO';
import { ICustomer } from 'src/Model/ICustomer';

import { catchError, Observable, of, tap} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl = environment.masterDataApi.ui + '/Customers';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

  addCustomer(dto: CustomerDTO): Observable<ICustomer> {
    return this.http.post<ICustomer>(this.baseUrl, dto, this.httpOptions).pipe(
     tap((newLog: ICustomer) => this.log(` w/ id=${newLog.id}`)),
      catchError(this.handleError<ICustomer>('AddCustomer'))
    );
  }

  /*Pesquisa Customer por company recebe infomaçao de backend*/
  getCustomerByCompany(Company: string): Observable<ICustomer[]> {
    const url = `${this.baseUrl}/company/${Company}`;
    return this.http.get<ICustomer[]>(url).pipe(
      catchError(this.handleError<ICustomer[]>('get Customers by company'))
    );
  }

   /*Pesquisa por todos customer, recebe infomaçao de backend*/
  getCustumerAll(): Observable<ICustomer[]> {
    const url = `${this.baseUrl}`;
    return this.http.get<ICustomer[]>(url).pipe(
      catchError(this.handleError<ICustomer[]>('get all Customers'))
    );
  }
  /*Pesquisa customer por id recebe infomaçao de backend*/
  getCustumerById(Id: string): Observable<ICustomer> {
    const url = `${this.baseUrl}/${Id}`;
    return this.http.get<ICustomer>(url).pipe(
      catchError(this.handleError<ICustomer>('get Customers by Id'))
    );
  }

  /*Elimina Customer por id envia infomaçao para backend*/
  deleteCustomerById(id: string): Observable<ICustomer> {
    const url = `${this.baseUrl}/hard/${id}`;
    return this.http.delete<ICustomer>(url).pipe(
      catchError(this.handleError<ICustomer>('delete Customers by Id'))
    );
  }

  /*Desactiva customer por id envia infomaçao para backend*/
  deactivateCustomerById(id: string): Observable<ICustomer> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<ICustomer>(url).pipe(
      catchError(this.handleError<ICustomer>('deactivate Customers by Id'))
    );
  }



private log(message: string) {

  if (message == 'AddCustomer failed: OK') {
    Swal.fire('Erro, nenhuma alteração efectuada');
  }
  else if (message == 'SearchCustomer failed: OK') {
    Swal.fire('Não existe Customer com este ID');
  } else if (message == 'getAllCustomers,[] failed: OK') {
    Swal.fire('Não existe Custmers');
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
