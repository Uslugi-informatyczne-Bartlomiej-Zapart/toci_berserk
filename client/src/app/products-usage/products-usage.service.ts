import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductsUsageService {

  constructor(private http: HttpClient) { }

  setProductUsage(idproducts: Number, quantity: Number, idusers: Number): Observable<any> {
    return this.http.post(config.EndpointUrl + 'ProductUsage', {idproducts: idproducts, quantity:quantity, idusers:idusers});
  }
}
