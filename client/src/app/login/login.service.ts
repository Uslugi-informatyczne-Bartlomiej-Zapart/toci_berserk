import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(password: string): Observable<boolean> {
    return this.http.post<boolean>('https://localhost:44391/User/Login', password);
  }
}
