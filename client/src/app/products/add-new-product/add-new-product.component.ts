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

  allCategoriesNames: any = []
  categoriesNamesPromptsShow = false
  categoriesNamesPrompts: any = []

  allCompaniesNames: any = []
  companiesNamesPromptsShow = false
  companiesNamesPrompts: any = []

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {
    this.prodCompService.getDeliveryCompanies().subscribe(response => {
      console.log(response)
      this.allCompaniesNames = response
    })

    this.prodCompService.getCategories().subscribe(response => {
      console.log(response)
      this.allCategoriesNames = response
    })

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
    this.categoriesNamesPromptsShow = false

    this.model.category = value
  }

  showCompaniesPrompt() {
    if(this.model.companyName.length == 0) {
      this.companiesNamesPrompts = this.allCompaniesNames
    } else {
      this.companiesNamesPrompts = Object.values(this.allCompaniesNames)
                                      .filter((c: any) => c.toLowerCase().includes(this.model.companyName.toLowerCase()))
    }

    this.companiesNamesPromptsShow = true
  }

  showCategoriesPrompt() {
    if(this.model.category.length == 0) {
      this.categoriesNamesPrompts = this.allCategoriesNames
    } else {
      this.categoriesNamesPrompts = this.allCategoriesNames
                                      .filter((c: any) => c.name.toLowerCase().includes(this.model.category.toLowerCase()))
    }
    this.categoriesNamesPromptsShow = true
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
