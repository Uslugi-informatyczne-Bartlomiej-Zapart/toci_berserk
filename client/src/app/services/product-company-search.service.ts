import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from 'src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductCompanySearchService {

  getDeliverCompaniesURL = "ProductCompany/Search"
  getProductsFromCompanyURL = "Order/AllProductsFromCurrentCompany?companyId="

  constructor(private http: HttpClient) { }

  getDeliveryCompanies(model: any) {
    let x = config.EndpointUrl + "" + this.getDeliverCompaniesURL + "?query=" + model
    console.log(x)
    return this.http.get(x)
  }

  findProductsForCompany(name: any) {
    let x = config.EndpointUrl + "" + this.getProductsFromCompanyURL + "" + name
    console.log(x)
    return this.http.get(x)
  }


}
