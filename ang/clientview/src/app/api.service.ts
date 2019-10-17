import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Department } from './departmentclass';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = '../api/department';
//const apiUrl = 'http://localhost:51195/api/department';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  
  getDepartment (): Observable<Department[]> {
  return this.http.get<Department[]>(apiUrl)
    .pipe(
      tap(heroes => console.log('fetched departments')),
      catchError(this.handleError('getDepartment', []))
    );
}
  
  addDepart (depart: Department): Observable<Department[]> {     
    //this.http.post(apiUrl, depart, httpOptions).subscribe(response => {x=response});
    //this.http.post<Department[]>(apiUrl, depart, httpOptions).pipe(catchError(this.handleError('addDepart', depart)));
  return this.http.post<Department[]>(apiUrl,depart,httpOptions);
  
}

deleteDepart (id: number): Observable<Department[]> {
  const url = `${apiUrl}/${id}`;
  
  //this.http.delete(url, httpOptions).subscribe(response => console.log(response));
  return this.http.delete<Department[]>(url, httpOptions).pipe(   
    catchError(this.handleError<Department[]>('deleteDepart'))
  );
}

EditDepart(depart:Department):Observable<Department[]>{
  //this.http.put(apiUrl,depart,httpOptions).subscribe(response=>console.log(response));
  return this.http.put<Department[]>(apiUrl,depart,httpOptions);
}
  private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}
}


