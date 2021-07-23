import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  register(companyName: string, ownerSurname: string, login: string, password: string): Observable<any> {
      return this.http.post(config.EndpointUrl + 'User/Register', {companyName: companyName, ownerSurname: ownerSurname, login: login, password: password});
  }
}
