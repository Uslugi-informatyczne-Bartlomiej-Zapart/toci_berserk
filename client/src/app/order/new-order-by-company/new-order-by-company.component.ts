import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { config } from 'rxjs';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';

@Component({
  selector: 'app-new-order-by-company',
  templateUrl: './new-order-by-company.component.html',
  styleUrls: ['./new-order-by-company.component.scss']
})
export class NewOrderByCompanyComponent implements OnInit {

  deliveryName: string = ""

  foundedCompanies: any = []

  foundedProducts: any = []

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {

  }

  addProduct(idx: number) {
    this.foundedProducts[idx].added = true
    console.log(this.foundedProducts)
  }

  searchDeliveriesByCharacters(form: NgForm) {
      console.log(form.value)
      if(form.value.name?.length == 0) return

      this.prodCompService.getDeliveryCompanies(form.value.name).subscribe(response => {
        console.log(response)
        this.foundedCompanies = response
      })

  }

  findProductsForCompany(idx: number) {
    console.log(idx)
    let companyName = this.foundedCompanies[idx].iddeliverycompany
    console.log(companyName)
    this.prodCompService.findProductsForCompany(companyName).subscribe(response => {
      console.log(response)
      this.foundedProducts = response
      this.deliveryName = ""
      this.foundedCompanies = []
    })

  }



}
