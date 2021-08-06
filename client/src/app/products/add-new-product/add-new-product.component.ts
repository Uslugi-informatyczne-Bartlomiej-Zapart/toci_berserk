import { Component, OnInit } from '@angular/core';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-new-product',
  templateUrl: './add-new-product.component.html',
  styleUrls: ['./add-new-product.component.scss']
})
export class AddNewProductComponent implements OnInit {

  model = {
    Name: "",
    Manufacturer: "",
    Reference: "",

    Chemistry: {
      productCode: null,
      category: "",
      quantity: 0,

    }
  }


  allCategoriesNames: any = []
  categoriesNamesPromptsShow = false
  categoriesNamesPrompts: any = []

  allCompaniesNames: any = []
  companiesNamesPromptsShow = false
  companiesNamesPrompts: any = []

  constructor(private prodCompService: ProductCompanySearchService,
    private productService: ProductsService) { }

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

   this.productService.addProduct(this.model).subscribe(response => {
      console.log(response)
    })

    //this.resetProductModel()
  }

  selectCompany(value: any) {
    this.companiesNamesPromptsShow = false

    this.model.Manufacturer = value
  }

  selectCategory(value: any) {
    this.categoriesNamesPromptsShow = false

    this.model.Chemistry.category = value
  }

  showCompaniesPrompt() {
    console.log(this.model.Manufacturer)
    console.log(this.allCompaniesNames)
    if(this.model.Manufacturer.length == 0) {
      this.companiesNamesPrompts = this.allCompaniesNames
    } else {
      this.companiesNamesPrompts = Object.values(this.allCompaniesNames)
                                      .filter((c: any) => { console.log(c); return c.toLowerCase().includes(this.model.Manufacturer.toLowerCase())} )
    }

    this.companiesNamesPromptsShow = true
  }

  showCategoriesPrompt() {
    if(this.model.Chemistry.category.length == 0) {
      this.categoriesNamesPrompts = this.allCategoriesNames
    } else {
      this.categoriesNamesPrompts = this.allCategoriesNames
                                      .filter((c: any) => c.name.toLowerCase().includes(this.model.Chemistry.category.toLowerCase()))
    }
    this.categoriesNamesPromptsShow = true
  }

  quantityUp() {
    this.model.Chemistry.quantity++
  }

  quantityDown() {
    this.model.Chemistry.quantity--
  }

  resetProductModel() {

    this.model = {
      Reference: "",
      Name: "",
      Manufacturer: "",
      Chemistry: {
        productCode: null,
        category: "",
        quantity: 0,

      }
    }

  }

}
