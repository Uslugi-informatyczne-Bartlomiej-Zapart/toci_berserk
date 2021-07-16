import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class OrderHistoryService {

  constructor(private http: HttpClient) { }

  getAllHistoryOrders(dateFrom: Date, dateTo: Date): Observable<any> {
    return this.http.get(config.EndpointUrl + 'Order/HistoryOrders'+ '?dateFrom=' + dateFrom + '&dateTo=' + dateTo);
  }
}
