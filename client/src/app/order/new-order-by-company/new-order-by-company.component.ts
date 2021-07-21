import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProductCompanySearchService } from 'src/app/services/product-company-search.service';

@Component({
  selector: 'app-new-order-by-company',
  templateUrl: './new-order-by-company.component.html',
  styleUrls: ['./new-order-by-company.component.scss']
})
export class NewOrderByCompanyComponent implements OnInit {

  deliveryName: string = ""

  foundedCompanies: any = []

  constructor(private prodCompService: ProductCompanySearchService) { }

  ngOnInit(): void {

  }

  searchDeliveriesByCharacters(form: NgForm) {
      console.log(form.value)
      this.prodCompService.getDeliveryCompanies(form.value.name).subscribe(response => {
        console.log(response)
        this.foundedCompanies = response
      })

  }

}
