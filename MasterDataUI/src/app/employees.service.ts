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
export class EmployeesService {
  baseUrl = environment.masterDataApi.ui + '/Employees';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  
  addEmployee(dto: EmployeeDTO): Observable<IEmployee> {
    return this.http.post<IEmployee>(this.baseUrl, dto, this.httpOptions).pipe(
    tap((newLog: IEmployee) => this.log(` w/ id=${newLog.id}`)),
      catchError(this.handleError<IEmployee>('AddEmployee'))
    );
  }

  /*Pesquisa employee por nome recebe infomaçao de backend*/
  getEmployeeByName(name: string): Observable<IEmployee[]> {
    const url = `${this.baseUrl}/name/${name}`;
    return this.http.get<IEmployee[]>(url).pipe(
      catchError(this.handleError<IEmployee[]>('get Employee by name'))
    );
  }

    /*Pesquisa por todos employees, recebe infomaçao de backend*/
    getEmployeeAll(): Observable<IEmployee[]> {
      const url = `${this.baseUrl}`;
      return this.http.get<IEmployee[]>(url).pipe(
        catchError(this.handleError<IEmployee[]>('get all Employees'))
      );
    }

  /*Pesquisa Employee por id recebe infomaçao de backend*/
  getEmployeeById(Id: string): Observable<IEmployee> {
    const url = `${this.baseUrl}/${Id}`;
    return this.http.get<IEmployee>(url).pipe(
      catchError(this.handleError<IEmployee>('get Employees by Id'))
    );
  }

  /*Elimina Employee por id envia infomaçao para backend*/
  deleteEmployeeById(id: string): Observable<IEmployee> {
    const url = `${this.baseUrl}/hard/${id}`;
    return this.http.delete<IEmployee>(url).pipe(
      catchError(this.handleError<IEmployee>('delete Employees by Id'))
    );
  }
   
  /*Desactiva Employee por id envia infomaçao para backend*/
  deactivateEmployeeById(id: string): Observable<IEmployee> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<IEmployee>(url).pipe(
      catchError(this.handleError<IEmployee>('deactivate Employees by Id'))
    );
  }
    


/*
  async updateUser(userProfile: UserProfile): Promise<User | undefined>{

    let user: User = <User>userProfile;
    user.id = this.getCurrentUser();
    
    const url = `${this.usersControllerUrl}/${user.id}`;

    return firstValueFrom(this.http.put<User>(url, user, { responseType: 'json' })
    .pipe(
      catchError(this.handleError<User>('updating User')))).then(async updatedUser => {
        console.log(updatedUser);

        if(updatedUser != undefined){;
          return updatedUser
        } else return undefined;
        }
      );
  }

  async deleteUserAccount(userId: string) {
    const url = `${this.usersControllerUrl}/${userId}`;

    return this.http.delete<any>(url).subscribe(response => {
      if(response.status==='200'){
        this.cookieService.delete(this.userCookieName);
      }
    })
  }
*/

private log(message: string) {

  if (message == 'AddEmployee failed: OK') {
    Swal.fire('Erro, nenhuma alteração efectuada');
    console.log(message);

  }
  else if (message == 'SearchEmployee failed: OK') {
    Swal.fire('Não existe Employee com este ID');
  } else if (message == 'getAllEmployees,[] failed: OK') {
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
