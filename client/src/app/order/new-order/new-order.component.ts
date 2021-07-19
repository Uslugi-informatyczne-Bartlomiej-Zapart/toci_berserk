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
  dict:any = [];
  formOrder!: FormGroup;
  formSearch!: FormGroup;
  orders: any = [];
  products = [];
  displayedOrderColumns = ['productId', 'productName', 'currentQuantity', 'expectedOrderQuantity', 'deliveryCompany', 'price'];
  displayedProductColumns = ['canAdd', 'name', 'reference', 'manufacturer', 'code', 'companyName', 'price'];
  json: LooseObject = {};

  constructor(private listService: NewOrdersService, private fb: FormBuilder) { }

  ngOnInit(): void {

    this.listService.getNewProductsOrder().subscribe(x => {
      console.log(x);
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

  onInput() {

    let controls = this.formSearch.value;

    this.listService.searchProduct(controls.searchQuery).subscribe(x => {
      this.products = x;
    });
    console.log(this.products);
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

  click(el: any) {
    console.log(el);
    this.orders.push(el);
    //this.orders.refresh();
    console.log(this.orders);
  }
}
