import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from 'src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductCompanySearchService {

  getDeliverCompaniesURL = "Order/Deliverycompanies"
  getCategoriesURL = "Category/GetAllCategories"
  getProductsFromCompanyURL = "Order/AllProductsFromCurrentCompany?companyId="

  constructor(private http: HttpClient) { }

  getDeliveryCompanies() {
    let x = config.EndpointUrl + "" + this.getDeliverCompaniesURL
    return this.http.get(x)
  }

  findProductsForCompany(name: any) {
    let x = config.EndpointUrl + "" + this.getProductsFromCompanyURL + "" + name
    return this.http.get(x)
  }

  getCategories() {
    let x = config.EndpointUrl + "" + this.getCategoriesURL
    return this.http.get(x)
  }
}
