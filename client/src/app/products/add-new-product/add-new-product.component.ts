import { Component, OnInit } from '@angular/core';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';

@Component({
  selector: 'app-add-new-product',
  templateUrl: './add-new-product.component.html',
  styleUrls: ['./add-new-product.component.scss']
})
export class AddNewProductComponent implements OnInit {

  model = {
    productCode: "",
    productReference: "",
    productName: "",
    companyName: "",
    category: "",
    quantity: 0,
  }

  allCategories: any = []
  categoriesPrompts: [] = []
  categoriesPromptsShow = false

  allCompaniesNames: any = []
  companiesNamesPromptsShow = false
  companiesNamesPrompts: any = []

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {
    this.prodCompService.getDeliveryCompanies().subscribe(response => {
      console.log(response)
      this.allCompaniesNames = response
    })

    /*this.prodCompService.getAllCategories().subscribe(response => {
      console.log(response)
    })*/

  }

  addProduct() {
    console.log(this.model)
    console.log("adding new project to api")

    this.resetProductModel()
  }

  selectCompany(value: any) {
    this.companiesNamesPromptsShow = false

    this.model.companyName = value
  }

  selectCategory(value: any) {
    this.categoriesPromptsShow = false

    this.model.category = value
  }

  showCompaniesPrompt() { console.log(2)
    if(this.model.companyName.length == 0) {
      this.companiesNamesPrompts = this.allCompaniesNames
    } else {
      this.companiesNamesPrompts = Object.values(this.allCompaniesNames)
                                      .filter((comp: any) => comp.includes(this.model.companyName))
    }

    this.companiesNamesPromptsShow = true
  }

  getCategoriesPrompt() {

  }

  quantityUp() {
    this.model.quantity++
  }

  quantityDown() {
    this.model.quantity--
  }

  resetProductModel() {

    this.model = {
      productCode: "",
      productReference: "",
      productName: "",
      companyName: "",
      category: "",
      quantity: 0,
    }

  }

}
