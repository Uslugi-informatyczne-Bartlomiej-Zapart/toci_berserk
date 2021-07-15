import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(password: string): Observable<boolean> {
    return this.http.post<boolean>(config.EndpointUrl + 'User/Login', password);
  }
}
