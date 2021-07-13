import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  register(name: string, password: string): Observable<any> {
      return this.http.post('http://localhost:44391/User/Register', {name: name, password: password});
  }
}
