import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from 'src/assets/config';

@Injectable({
  providedIn: 'root'
})
export class ProductCompanySearchService {

  getDeliverCompaniesURL = "companies/searchCompanies"

  constructor(private http: HttpClient) { }

  getDeliveryCompanies(model: any) {
    return this.http.get(config.EndpointUrl + "" + this.getDeliverCompaniesURL + "/" + model)
  }
}
