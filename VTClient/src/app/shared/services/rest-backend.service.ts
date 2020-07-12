import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RestBackendService {
  // baseUrl = 'http://localhost:32768';
  baseUrl = 'http://localhost:62797';

constructor(private http: HttpClient) { }

getTickets(): Observable<any>{
  return this.http.get(`${this.baseUrl}/api/ticket`).pipe(tap(a => console.log(a)));
}

}
