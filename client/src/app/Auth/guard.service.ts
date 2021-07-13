import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(private http: HttpClient) { }

  getUser(): Observable<any> {
    return this.http.get<any>("https://localhost:44391/User/Users");
  }
}
