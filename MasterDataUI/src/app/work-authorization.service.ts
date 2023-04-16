import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { WorkAuthorizationDTO } from 'src/app/DTO/WorkAuthorizationDTO';
import { IWorkAuthorization } from 'src/Model/IWorkAuthorization';
import { catchError, Observable, of, Subject, tap} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkAuthorizationService {

  baseUrl = environment.masterDataApi.ui + '/WorkAuthorizations';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };


  private subjectName = new Subject<IWorkAuthorization>(); //need to create a subject

  private subjectNameE = new Subject<IWorkAuthorization>(); //need to create a subject

  private subjectNameV = new Subject<IWorkAuthorization>(); //need to create a subject

  addWorkAuthorization(dto: WorkAuthorizationDTO): Observable<IWorkAuthorization> {
    return this.http.post<IWorkAuthorization>(this.baseUrl, dto, this.httpOptions).pipe(
    tap((newLog: IWorkAuthorization) => this.log(` w/ id=${newLog.id}`)),
      catchError(this.handleError<IWorkAuthorization>('AddWorkAuthorization'))
    );
  }

   /*Pesquisa WorkAuthorization por nome empresa recebe infomaçao de backend*/
   getWorkAuthorizationByCompany(name: string): Observable<IWorkAuthorization[]> {
    const url = `${this.baseUrl}/WorkAuthorization/${name}`;
    return this.http.get<IWorkAuthorization[]>(url).pipe(
      catchError(this.handleError<IWorkAuthorization[]>('get WorkAuthorization by name'))
    );
  }

    /*Pesquisa por todos WorkAuthorizations, recebe infomaçao de backend*/
    getWorkAuthorizationAll(): Observable<IWorkAuthorization[]> {
      const url = `${this.baseUrl}`;
      return this.http.get<IWorkAuthorization[]>(url).pipe(
        catchError(this.handleError<IWorkAuthorization[]>('get all WorkAuthorizations'))
      );
    }

  /*Pesquisa WorkAuthorization por id recebe infomaçao de backend*/
  getWorkAuthorizationById(Id: string): Observable<IWorkAuthorization> {
    const url = `${this.baseUrl}/${Id}`;
    return this.http.get<IWorkAuthorization>(url).pipe(
      catchError(this.handleError<IWorkAuthorization>('get WorkAuthorization by Id'))
    );
  }

   /*Elimina Report por id envia infomaçao para backend*/
   deleteWorkAuthorizationById(id: string): Observable<IWorkAuthorization> {
    const url = `${this.baseUrl}/hard/${id}`;
    return this.http.delete<IWorkAuthorization>(url).pipe(
      catchError(this.handleError<IWorkAuthorization>('delete WorkAuthorizations by Id'))
    );
  }
   
  /*Desactiva Employee por id envia infomaçao para backend*/
  deactivateWorkAuthorizationById(id: string): Observable<IWorkAuthorization> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<IWorkAuthorization>(url).pipe(
      catchError(this.handleError<IWorkAuthorization>('deactivate WorkAuthorization by Id'))
    );
  }


  sendUpdate(user: IWorkAuthorization) { //the component that wants to update something, calls this fn
    this.subjectName.next(user); //next() will feed the value in Subject
  }

  getUpdate(): Observable<IWorkAuthorization> { //the receiver component calls this function 
    return this.subjectName.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
  }

  sendUpdateE(user: IWorkAuthorization) { //the component that wants to update something, calls this fn
    this.subjectNameE.next(user); //next() will feed the value in Subject
  }

  getUpdateE(): Observable<IWorkAuthorization> { //the receiver component calls this function 
    return this.subjectNameE.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
  }

  sendUpdateV(user: IWorkAuthorization) { //the component that wants to update something, calls this fn
    this.subjectNameE.next(user); //next() will feed the value in Subject
  }

  getUpdateV(): Observable<IWorkAuthorization> { //the receiver component calls this function 
    return this.subjectNameE.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
  }




  private log(message: string) {

    if (message == 'AddWorkAuthorization failed: OK') {
      Swal.fire('Erro, nenhuma alteração efectuada');
      console.log(message);
  
    }
    else if (message == 'SearchWorkAuthorization failed: OK') {
      Swal.fire('Não existe WorkAuthorization com este ID');
    } else if (message == 'getAllWorkAuthorizations,[] failed: OK') {
      Swal.fire('Não existe WorkAuthorization');
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
  