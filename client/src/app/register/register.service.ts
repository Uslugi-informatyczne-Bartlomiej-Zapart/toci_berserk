import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  register(name: string, login: string, password: string): Observable<any> {
      return this.http.post('https://localhost:44391/User/Register', {name: name, login: login, password: password});
  }
}
