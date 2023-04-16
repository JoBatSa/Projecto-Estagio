
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { ILogin } from 'src/Model/ILogin';
import { ILoginId } from 'src/Model/ILoginId';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import Swal from 'sweetalert2';

import {map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseUrl = environment.masterDataApi.ui + '/Login';

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };



 newLogin (login: ILogin): Observable<ILoginId> {

   return this.http.post<ILoginId>(this.baseUrl, login, this.httpOptions).pipe(
      tap((newLog: ILoginId) => this.log(` w/ id=${newLog.id}`)),
      catchError(this.handleError<ILoginId>('login'))
    );
  }

  private log(message: string) {

   if (message== 'login failed: OK'){
    Swal.fire('user ou password errado');
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
