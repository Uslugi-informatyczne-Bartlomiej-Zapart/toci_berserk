import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NewOrdersService } from './new-order.service';

interface LooseObject {
  [key: string]: any
}

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {

  arr: any = [];
  dict = [];
  formOrder!: FormGroup;
  formSearch!: FormGroup;
  orders = [];
  products = [];
  displayedOrderColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price'];
  displayedProductColumns = ['canAdd', 'code', 'companyName', 'idDeliveryCompany', 'idProducts', 'manufacturer', 'name'];
  json: LooseObject = {};

  constructor(private listService: NewOrdersService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.listService.getNewProductsOrder().subscribe(x => {

      this.orders = x;

      for (let i = 0; i < this.orders.length; i++)
      {
        this.dict.push(this.orders[i]['productid']);
        this.json['expectedQuantity' + this.orders[i]['productid']] = new FormControl(this.orders[i]['expectedOrderQuantity']);
      }

      this.formOrder = this.fb.group(this.json);
    });

    this.formSearch = this.fb.group({searchQuery: new FormControl()});
  }

  onSubmitSearch() {
    let controls = this.formSearch.value;

    this.listService.searchProduct(controls.searchQuery).subscribe(x => {
      this.products = x;
    });
  }

  onSubmit() {
    let controls = this.formOrder.value;

    for (let key in this.dict) {
      let value = this.dict[key];

      let q = {productId: value, expectedOrderQuantity: controls['expectedQuantity'+value]};
      this.arr.push(q);
    }

    this.listService.getAllValuesFromOrderForm(this.arr).subscribe(x => {
      this.orders = x;
    });
  }

  change() {
    console.log("asd");
  }
}
