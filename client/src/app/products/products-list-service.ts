import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from '../../../src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductsListService {

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<any> {
    return this.http.get(config.EndpointUrl + 'Product/Products');
  }
}
