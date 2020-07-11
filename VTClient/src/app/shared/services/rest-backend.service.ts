import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestBackendService {
  baseUrl = 'http://localhost:32768';

constructor(private http: HttpClient) { }

getTickets(): Observable<any>{
  return this.http.get(`${this.baseUrl}/api/ticket`);
}

}
