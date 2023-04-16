import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ReportDTO} from 'src/app/DTO/ReportDTO';
import { IReport } from 'src/Model/IReport';


import { catchError, Observable, of, Subject, tap} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  baseUrl = environment.masterDataApi.ui + '/Reports';  // URL to web api
  
  constructor(private http: HttpClient) { }
 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };



  private subjectName = new Subject<IReport>(); //need to create a subject

  sendUpdate(user: IReport) { //the component that wants to update something, calls this fn
    this.subjectName.next(user); //next() will feed the value in Subject
  }

  getUpdate(): Observable<IReport> { //the receiver component calls this function 
    return this.subjectName.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
  }



  addReport(dto: ReportDTO): Observable<IReport> {

    return this.http.post<IReport>(this.baseUrl, dto, this.httpOptions).pipe(
      tap((newLog: IReport) => this.log(` w/ id=${newLog.id}`)),
      catchError(this.handleError<IReport>('AddReport'))
    );
  }


    
  /*Pesquisa Report por Employee recebe infomaçao de backend*/
  getReportByName(Name: string): Observable<IReport[]> {
    const url = `${this.baseUrl}/name/${Name}`;
    return this.http.get<IReport[]>(url).pipe(
      catchError(this.handleError<IReport[]>('get Reports by name'))
    );
  }

  /*Pesquisa Report por company recebe infomaçao de backend*/
  getReportByCompany(Company: string): Observable<IReport[]> {
    const url = `${this.baseUrl}/company/${Company}`;
    return this.http.get<IReport[]>(url).pipe(
      catchError(this.handleError<IReport[]>('get Reports by company'))
    );
  }

  /*Pesquisa por todos report, recebe infomaçao de backend*/
  getReportAll(): Observable<IReport[]> {
    const url = `${this.baseUrl}`;
    return this.http.get<IReport[]>(url).pipe(
      catchError(this.handleError<IReport[]>('get all Reports'))
    );
  }


  /*Pesquisa Report por id recebe infomaçao de backend*/
  getReportById(Id: string): Observable<IReport[]> {
    const url = `${this.baseUrl}/${Id}`;
    return this.http.get<IReport[]>(url).pipe(
      catchError(this.handleError<IReport[]>('get Reports by Id'))
    );
  }

  /*Elimina Report por id envia infomaçao para backend*/
  deleteReportById(Id: string): Observable<IReport[]> {
    const url = `${this.baseUrl}/hard/${Id}`;
    return this.http.delete<IReport[]>(url).pipe(
      catchError(this.handleError<IReport[]>('delete Reports by Id'))
    );
  }



/*Pesquisa utilizador por email recebe infomaçao de backend*/
/*
getUsersByEmail(userEmail: string): Observable<IReport[]> {
  const url = `${this.baseUrl}/SearchByEmail/${userEmail}`;
  return this.http.get<IReport[]>(url).pipe(
    catchError(this.handleError<IReport[]>('get Users by email'))
  );
}

*/

    private log(message: string) {

      if (message == 'Add profile user failed') {
        Swal.fire('Erro, nenhuma alteração efectuada');
      }
      else if (message == 'SearchReport failed: OK') {
        Swal.fire('Não existe Report com este ID');
      } else if (message == 'getAllReports,[] failed: OK') {
        Swal.fire('Não existe Reports');
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
    