import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../assets/config';

@Injectable({
  providedIn: 'root'
})
export class OrdersListService {

  constructor(private http: HttpClient) { }

  getAllOrders(): Observable<any> {
    return this.http.get(config.EndpointUrl + 'Order/Orders');
  }
}
