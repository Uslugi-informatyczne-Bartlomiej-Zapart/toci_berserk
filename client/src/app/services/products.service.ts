import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from 'src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  addNewProduct = "Product/addNewProduct"

  constructor(private http: HttpClient) { }

  addProduct(model: any) {
    let x = config.EndpointUrl + "" + this.addNewProduct
    return this.http.post(x, model)
  }



}
