import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Product } from 'src/app/models/Product';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';

@Component({
  selector: 'app-new-order-by-company',
  templateUrl: './new-order-by-company.component.html',
  styleUrls: ['./new-order-by-company.component.scss']
})
export class NewOrderByCompanyComponent implements OnInit {

  deliveryInputValue: string = ""

  allDeliveryCompanies: any = []

  foundedCompanies: any = []

  foundedProducts: Product[] = []

  addedProducts: Product[] = []

  nowFoundedProductsCompanyName: any = ""

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {
    this.prodCompService.getDeliveryCompanies().subscribe((response: any) => {
      this.allDeliveryCompanies = response
    })
  }

  addProduct(idx: number) {

    let prod = Object.assign({}, this.foundedProducts[idx]);

    this.addedProducts.push(prod)

    this.foundedProducts[idx].added = true
  }

  addProducts() {
    console.log("Add all products to db")
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
        this.nowFoundedProductsCompanyName = value
        break
      }
    }

    this.prodCompService.findProductsForCompany(foundedId).subscribe( (response: any) => {

      this.foundedProducts = response
      this.deliveryInputValue = ""
      this.foundedCompanies = []
    })

  }

  deleteProduct(idx: number) {
    let name = this.addedProducts[idx].productName

    this.setNotAdded(name)

    this.addedProducts.splice(idx, 1)
  }

  setNotAdded(name: string) {

    for (const [key, value] of Object.entries(this.foundedProducts)) {

      if(value.productName == name) {
        value.added = false
        return
      }
    }
  }

  resetView() {
    this.foundedProducts = []
    this.addedProducts = []
    this.nowFoundedProductsCompanyName = ""
  }

  quantityUp(idx: number) {
    this.addedProducts[idx].quantity++
  }

  quantityDown(idx: number) {
    this.addedProducts[idx].quantity--
  }

}
