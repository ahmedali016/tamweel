import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import {jobtitle} from './jobtitleclass';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = '../api/JobTitle';
//const apiUrl = 'http://localhost:51195/api/JobTitle';
@Injectable({
  providedIn: 'root'
})
export class JobApiService {

  constructor(private http: HttpClient) { }
  
  getjobs (): Observable<jobtitle[]> {
  return this.http.get<jobtitle[]>(apiUrl)
    .pipe(
      tap(heroes => console.log('fetched jobtitle')),
      catchError(this.handleError('getjobs', []))
    );
  }
  
  addJob (job: jobtitle): Observable<jobtitle[]> {     
          
  return this.http.post<jobtitle[]>(apiUrl, job, httpOptions);
  
  }
  
  deleteJob (id: number): Observable<jobtitle[]> {
  const url = `${apiUrl}/${id}`;
  
  //this.http.delete(url, httpOptions).subscribe(response => console.log(response));
  return this.http.delete<jobtitle[]>(url, httpOptions);
  
}

EditJob(job:jobtitle): Observable<jobtitle[]>{
  
  return this.http.put<jobtitle[]>(apiUrl,job,httpOptions);
  
  
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
