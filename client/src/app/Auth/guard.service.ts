import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(private http: HttpClient) { }

  getUser(): Observable<any> {
    console.log(this.http.get<any>("https://localhost:44391/User/Users"));
    return this.http.get<any>("https://localhost:44391/User/Users");
  }
}
