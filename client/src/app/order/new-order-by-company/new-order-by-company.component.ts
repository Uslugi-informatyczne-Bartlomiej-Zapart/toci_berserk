import { componentFactoryName } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { config } from 'rxjs';
import { Company, MyGroupCompanies } from 'src/app/models/Company';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';

@Component({
  selector: 'app-new-order-by-company',
  templateUrl: './new-order-by-company.component.html',
  styleUrls: ['./new-order-by-company.component.scss']
})
export class NewOrderByCompanyComponent implements OnInit {

  deliveryName: string = ""

  allDeliveryCompanies: any = []

  foundedCompanies: any = []

  foundedProducts: any = []

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {
    this.prodCompService.getDeliveryCompanies().subscribe((response: any) => {
      console.log(response)
      this.allDeliveryCompanies = response
    })
  }

  addProduct(idx: number) {

  }

  searchDeliveriesByCharacters(form: NgForm) {

    if(form.value.name?.length == 0) return

    let searchChars = form.value.name

    this.foundedCompanies = Object.values(this.allDeliveryCompanies)
                              .filter((comp: any) => comp.includes(searchChars))
  }

  findProductsForCompany(idx: number) {
    let foundedId;
    for (const [key, value] of Object.entries(this.allDeliveryCompanies)) {
      if(value == this.foundedCompanies[idx]) {
        foundedId = key
        break
      }
    }

    this.prodCompService.findProductsForCompany(foundedId).subscribe( (response: any) => {
      console.log(response)
      this.foundedProducts = response
      this.deliveryName = ""
      this.foundedCompanies = []
    })

  }



}
