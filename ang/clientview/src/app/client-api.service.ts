import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import {clients}from './clientclass';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = '../api/Clients';
//const apiUrl = 'http://localhost:51195/api/Clients';
@Injectable({
  providedIn: 'root'
})
export class ClientApiService {

  constructor(private http:HttpClient) { }
  
  getClient():Observable<clients[]>{
    
    return this.http.get<clients[]>(apiUrl).pipe(
      tap(clin => console.log('fetched clients')),
      catchError(this.handleError('getDepartment', []))
    );
  }
  
  addClient(frm:FormData):Observable<boolean>{
    console.log(frm);
    //this.http.post(apiUrl,frm,httpOptions).subscribe();
    return this.http.post<boolean>(apiUrl,frm);
  }
  
  deleteClient(id:number):Observable<clients[]>{
    const url = `${apiUrl}/${id}`;
    return this.http.delete<clients[]>(url,httpOptions);
  }
  
  getClientData(id:number):Observable<clients>{
    const url = `${apiUrl}/${id}`;
    return this.http.get<clients>(url,httpOptions);
  }
  
  editClient(frm:FormData):Observable<boolean>{
      
    return this.http.put<boolean>(apiUrl,frm);
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
