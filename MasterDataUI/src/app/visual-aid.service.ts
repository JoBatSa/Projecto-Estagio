import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { VisualAidDTO} from 'src/app/DTO/VisualAidDTO';
import { IVisualAid} from 'src/Model/IVisualAid';

import { catchError, Observable, of, Subject, tap} from 'rxjs';
import { IWorkOrder } from 'src/Model/IWorkOrder';

@Injectable({
  providedIn: 'root'
})
export class VisualAidService {

  baseUrl = environment.masterDataApi.ui + '/VisualAids';  // URL to web api
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private subjectName = new Subject<IWorkOrder>(); //need to create a subject

  sendUpdate(user: IWorkOrder) { //the component that wants to update something, calls this fn
    this.subjectName.next(user); //next() will feed the value in Subject
  }

  getUpdate(): Observable<IWorkOrder> { //the receiver component calls this function 
    return this.subjectName.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
  }

 // Returns an observable
 upload(file :File):Observable<any> {
 
  // Create form data
  const formData = new FormData(); 
    
  // Store form name as "file" with file data
  formData.append("file", file, file.name);
    
  // Make http post request over api
  // with formData as req
  var url= this.baseUrl+'/File';
  return this.http.put(url, formData)
}




  addVisualAid(dto: VisualAidDTO): Observable<IVisualAid> {
    return this.http.post<IVisualAid>(this.baseUrl, dto, this.httpOptions).pipe(
    tap((newLog: IVisualAid) => this.log(` w/ id=${newLog.id}`)),
    catchError(this.handleError<IVisualAid>('AddVisualAid'))
    );
  }


  /*Pesquisa por todos visualAid, recebe infomaçao de backend*/
  getVisualAidAll(): Observable<IVisualAid[]> {
    const url = `${this.baseUrl}`;
    return this.http.get<IVisualAid[]>(url).pipe(
    catchError(this.handleError<IVisualAid[]>('get all VisualAids'))
    );
  }

/*Pesquisa VisualAid por company recebe infomaçao de backend*/
  getVisualAidByCompany(Company: string): Observable<IVisualAid[]> {
    const url = `${this.baseUrl}/visualaid/${Company}`;
    return this.http.get<IVisualAid[]>(url).pipe(
    catchError(this.handleError<IVisualAid[]>('get VisualAid by company'))
    );
  }

 /*Pesquisa VisualAid por id recebe infomaçao de backend*/
 getCustumerById(Id: string): Observable<IVisualAid> {
  const url = `${this.baseUrl}/${Id}`;
  return this.http.get<IVisualAid>(url).pipe(
    catchError(this.handleError<IVisualAid>('get Customers by Id'))
  );
}

/*Elimina VisualAid por id envia infomaçao para backend*/
deleteCustomerById(id: string): Observable<IVisualAid> {
  const url = `${this.baseUrl}/hard/${id}`;
  return this.http.delete<IVisualAid>(url).pipe(
    catchError(this.handleError<IVisualAid>('delete Customers by Id'))
  );
}
 
/*Desactiva VisualAid por id envia infomaçao para backend*/
deactivateCustomerById(id: string): Observable<IVisualAid> {
  const url = `${this.baseUrl}/${id}`;
  return this.http.delete<IVisualAid>(url).pipe(
    catchError(this.handleError<IVisualAid>('deactivate Customers by Id'))
  );
}
















    private log(message: string) {

      if (message == 'CriarVisualAid failed: OK') {
        Swal.fire('Erro, nenhuma alteração efectuada');
      }
      else if (message == 'SearchVisualAid failed: OK') {
        Swal.fire('Não existe VisualAid com este ID');
      } else if (message == 'getAllVisualAids,[] failed: OK') {
        Swal.fire('Não existe VisualAid');
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
