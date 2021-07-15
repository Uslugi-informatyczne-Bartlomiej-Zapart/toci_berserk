import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrdersListService {

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<any> {
    return this.http.get('https://localhost:44391/Product/Products');
  }
}
