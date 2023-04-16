import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EmployeeDTO } from 'src/app/DTO/EmployeeDTO';
import { IEmployee } from 'src/Model/IEmployee';
import { catchError, Observable, of, tap} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.masterDataApi.ui + '/Administrators';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };


 /*Pesquisa Employee por id recebe infomaçao de backend*/
 getAdminId(Id: string): Observable<IEmployee> {
  const url = `${this.baseUrl}/${Id}`;
  return this.http.get<IEmployee>(url).pipe(
    catchError(this.handleError<IEmployee>('get Employees by Id'))
  );
}


private log(message: string) {

  if (message == 'AddEmployee failed: OK') {
    Swal.fire('Não existe Employee com este ID');
  }
  else if (message == 'getAllEmployees,[] failed: OK') {
    Swal.fire('Não existe Employee');
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
