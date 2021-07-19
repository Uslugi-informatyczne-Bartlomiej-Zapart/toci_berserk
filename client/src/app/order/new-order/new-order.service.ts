import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../assets/config';

@Injectable({
  providedIn: 'root'
})
export class NewOrdersService {

  constructor(private http: HttpClient) { }

  getNewProductsOrder(): Observable<any> {
    return this.http.get(config.EndpointUrl + 'ProductOrder/NewProductsOrder');
  }

  getAllValuesFromOrderForm(json: string): Observable<any> {
    return this.http.post(config.EndpointUrl + 'ProductOrder/SetNewProductsOrder', json);
  }

  searchProduct(param :string) : Observable<any> {
    return this.http.get(config.EndpointUrl+'ProductCompany/Search'+'?query='+param);
  }
}
