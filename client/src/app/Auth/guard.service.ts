import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'
import { config } from '../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(private http: HttpClient) { }

  getUser(): Observable<any> {
    return this.http.get<any>(config.EndpointUrl + "User/Users");
  }
}
